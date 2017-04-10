using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SocketIOClient;
using Microsoft.Win32;
using Quobject.SocketIoClientDotNet.Client;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media;

namespace Code_Editor
{

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        static readonly string Extensions = "C#|*.cs|" + "JavaScript|*.js|" +
            "HTML|*.htm|HTML|*.html|" +
            "ASP/XHTML|*.asp|ASP/XHTML|*.aspx|ASP/XHTML|*.asax|ASP/XHTML|*.asmx|ASP/XHTML|*.ascx|ASP/XHTML|*.master|" +
            "Boo|*.boo|" + "Coco|*.atg|" + "CSS|*.css|" + "C++|*.c|C++|*.h|C++|*.cc|C++|*.cpp|C++|*.hpp|" +
            "Java|*.java|" + "PHP|*.php|" + "VBNET|*.vb|" +
            "XML|.xml|XML|.xsl|XML|.xslt|XML|.xsd|XML|.manifest|XML|.config|XML|.addin|XML|.xshd|XML|.wxs|XML|.wxi|XML|.wxl|XML|.proj|XML|.csproj|XML|.vbproj|XML|.ilproj|XML|.booproj|XML|.build|XML|.xfrm|XML|.targets|XML|.xaml|XML|.xpt|XML|.xft|XML|.map|XML|.wsdl|XML|.disco|XML|.ps1xml|XML|.nuspec";
        SettingManager _SettingManager = new SettingManager();
        public SaveFileDialog sd = new SaveFileDialog();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer saveTimer = new DispatcherTimer();
        Socket socket = IO.Socket("http://iwin247.net:8080/");
        private string Current_File_Path = "";
        private string folder_path = "";
        System.Windows.Forms.SaveFileDialog digSave = new System.Windows.Forms.SaveFileDialog()
        {
            Filter = Extensions,
            Title = "File"
        };
        System.Windows.Forms.FolderBrowserDialog digFolder = new System.Windows.Forms.FolderBrowserDialog()
        {
            ShowNewFolderButton = true
        };
        #endregion
        public MainWindow()
        {
            if (!Setting.OnlineMode)
                MessageBox.Show("서버는 현재 오프라인 상태입니다.", "오프라인 모드", MessageBoxButton.OK, MessageBoxImage.Information);
            InitializeComponent();

            #region Initialize
            _SettingManager.Load_Setting();
            ApplySetting();
            //MessageBox.Show(Setting.Font + Setting.FontSize.ToString() + Setting.Color.ToString() + Setting.ImagePath + Setting.ID + Setting.PW);
            timer.Interval = TimeSpan.FromSeconds(0.1f);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            saveTimer.Interval = TimeSpan.FromMinutes(Setting.SaveTime);
            saveTimer.Tick += new EventHandler(saveTimer_Tick);
            saveTimer.Start();
            sd.Filter = "C# File|*.cs|Python File|*.py|HTML File|*.html|CSS File|*.css|JS File|*.js|C File|*.c|C++ File|*.cpp|Header File|*.h|Text File|*.txt";
            sd.Title = "저장";
            //socket.On(Socket.EVENT_CONNECT, () => { });
            //socket.On("message", (msg) =>
            //{
            //    Console.WriteLine(msg);
            //    recTXT += (msg + "\r\n");
            //});
            //socket.Connect();
            #endregion
            //Console.WriteLine("Message Send");
        }
        #region EventHandler
        private void saveTimer_Tick(object sender, EventArgs e)
        {
            if (Current_File_Path != "")
            {
                StreamWriter sw = new StreamWriter(Current_File_Path);
                sw.Write(CodeEditor.Text);
                sw.Close();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {


        }
        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
            if (digSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.Create(digSave.FileName, 1, FileOptions.None).Close();

                Current_File_Path = digSave.FileName;
                CodeEditor.Text = "";
                SetHighlightExtension(System.IO.Path.GetExtension(Current_File_Path));
                //MessageBox.Show(ReturnExtension(System.IO.Path.GetExtension(Current_File_Path)));
                CodeEditor.IsEnabled = true;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void oppoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //소켓을 열어주자
        }
        private void CodeEditor_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void CodeEditor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
            ApplySetting();
        }
        private void digFont_Click(object sender, RoutedEventArgs e)
        {
            var fontDig = new System.Windows.Forms.FontDialog()
            {
                ShowColor = false,
                ShowEffects = false
            };
            System.Drawing.Font memFont;
            if (fontDig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                memFont = fontDig.Font;
                CodeEditor.FontFamily = new FontFamily(memFont.Name);
                Setting.Font = memFont.Name;
                Setting.FontSize = Convert.ToInt32(memFont.Size);
                CodeEditor.FontSize = memFont.Size;
            }
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            CodeEditor.Cut();
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            CodeEditor.Paste();
        }
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            CodeEditor.Undo();
        }
        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            CodeEditor.Redo();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            /*
             * openFileDialog 한다음 확장자만 가져와서 SyntaxHighlighting을 설정해 준다.
             */
            var digOpen = new System.Windows.Forms.OpenFileDialog()
            {
                Title = "Open File"
            };
            if (digOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Current_File_Path = digOpen.FileName;
                var open = new StreamReader(digOpen.FileName);
                CodeEditor.Clear();
                CodeEditor.Text = open.ReadToEnd();
                SetHighlightExtension(System.IO.Path.GetExtension(digOpen.FileName));
                CodeEditor.IsEnabled = true;
                open.Close();
            }

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void addop_Click(object sender, RoutedEventArgs e)
        {
        }
        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            if (digFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder_path = digFolder.SelectedPath;
            }
        }
        private void lstFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("DoubleClicked");
        }
        private void Trans_Click(object sender, RoutedEventArgs e)
        {
            Translator t = new Translator();
            t.Show();
        }
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //다른 이름으로 저장
            {
                System.Windows.Forms.SaveFileDialog digSave = new System.Windows.Forms.SaveFileDialog()
                {
                    Title = "Save File",
                    Filter = Extensions
                };
                if (digSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var sw = new StreamWriter(digSave.FileName);
                    sw.Write(CodeEditor.Text);
                    sw.Close();
                }
            }
        }
        #endregion
        #region Functions
        private void SetHighlightExtension(string filext)
        {
            string[] temp = Extensions.Split('|');//[0]ASPX,[1]*.aspx[2]Boo[3]*.boo...
            //1,3,5,7,9,...,37,39
            string Ext = "";
            int cnt = 0;
            string t = "*" + filext;
            for (int i = 1; i < 40; i += 2)
            {
                if (string.Equals(t, temp[i]))
                {
                    Ext = temp[i];
                    cnt = i - 1;
                }
            }
            CodeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition(temp[cnt]);
        }
        //private void Folder_Add(string folderpath)
        //{
        //    lstFolder.Items.Clear();
        //    string[] files = Directory.GetFiles(folderpath);
        //    foreach (string file in files)
        //    {
        //        string filename = System.IO.Path.GetFileNameWithoutExtension(file);
        //        ListViewItem item = new ListViewItem()
        //        {
        //            Content = filename,
        //            Tag = file
        //        };
        //        lstFolder.Items.Add(item);
        //    }
        //}
        private void SaveFile()
        {
            if (Current_File_Path != "")
            {
                StreamWriter sw = new StreamWriter(Current_File_Path);
                sw.Write(CodeEditor.Text);
                sw.Close();
            }
        }
        //private void UpdateText(bool IsEditing)
        //{

        //}
        private void ApplySetting()
        {
            _SettingManager.Save_Setting();
            //Setter
            if (Setting.Color)
            {
                if (Setting.ColorID == "Transparent")
                {
                    var colorBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                    CodeEditor.Background = colorBrush;
                }
                else
                {
                    var colorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF" + Setting.ColorID));
                    CodeEditor.Background = colorBrush;
                }
            }
            else if (Setting.ImagePath == "")
            {
                var colorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF252525"));
                CodeEditor.Background = colorBrush;
            }
            else
            {
                try
                {
                    var imgBrush = new ImageBrush()
                    {
                        ImageSource = new BitmapImage(new Uri(Setting.ImagePath, UriKind.RelativeOrAbsolute))
                    };
                    CodeEditor.Background = imgBrush;
                }
                catch (Exception)
                {
                    var colorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF252525"));
                    CodeEditor.Background = colorBrush;
                }
            }

            CodeEditor.Background.Opacity = Setting.BackOpacity;
            saveTimer.Stop();
            saveTimer.Interval = TimeSpan.FromMinutes(Setting.SaveTime);
            saveTimer.Start();
            CodeEditor.FontSize = Setting.FontSize;
            CodeEditor.FontFamily = new FontFamily(Setting.Font);
        }
        //private void Update_Oppo()
        //{
        //    _Opponent = Setting.OppoList;
        //    //_Opponent.Add("New Opponent");
        //}
        #endregion

        private void lstFolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Menu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
