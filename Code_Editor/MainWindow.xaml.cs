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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SocketIOClient;
using Microsoft.Win32;
using Quobject.SocketIoClientDotNet.Client;
using System.Threading;
using System.Windows.Threading;

namespace Code_Editor
{
    
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public SaveFileDialog sd = new SaveFileDialog();
        string recTXT;
        DispatcherTimer timer = new DispatcherTimer();
        Socket socket = IO.Socket("http://iwin247.net:8080/");
        //Socket socket;   
        public MainWindow()
        {
            
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.1f);

            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            sd.Filter = "C# File|*.cs|Python File|*.py|HTML File|*.html|CSS File|*.css|JS File|*.js|C File|*.c|C++ File|*.cpp|Header File|*.h|Text File|*.txt";
            sd.Title = "저장";
            socket.On(Socket.EVENT_CONNECT, () => {

            });
            socket.On("message", (msg) => {
                Console.WriteLine(msg);
                recTXT += (msg + "\r\n");
            });
            socket.Connect();
            //Console.WriteLine("Message Send");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Message.Text = recTXT;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Code_Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string Text = new TextRange(CodeEdtior.Document.ContentStart, CodeEdtior.Document.ContentEnd).Text;
            //MessageBox.Show(Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                recTXT += ("me : \r\n");
                socket.Emit("message", SendTXT.Text); //Socket으로 메세지를 보낸다.
                SendTXT.Text = ""; //메세지를 보냈으니 초기화
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //socket.Disconnect();
        }

        private void CodeEditor_KeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Key가 '{'이고 그 다음 Enter가 눌린다면 Tab을 추가해줘야 한다?
             * '}'가 나오면 Tab을 하나 줄여줘야 한다? 
             */
        }

        private void oppoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
