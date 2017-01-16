using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Code_Editor
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static bool isReg = false;
        int picCnt = 0;
        int curTime = DateTime.Now.Hour;
        static string curPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Resources\Back\";
        System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();
        
        public LoginWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            ImageBrush imgB;
            NetworkInterface.Server_Status();
            picCnt = rnd.Next(1, 20);
            if (curTime > 4 && curTime < 17) //5~16시
            {
                imgB = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(curPath + @"D\" + picCnt.ToString() + ".jpg", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
            }
            else if (curTime > 16 && curTime < 22) //17~21시
            {
                imgB = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(curPath + @"S\" + picCnt.ToString() + ".jpg", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
            }
            else //22~4시
            {
                imgB = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(curPath + @"N\" + picCnt.ToString() + ".jpg", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
            }
            grid1.Background = imgB;
            _Timer.Interval = 10000; //20sec당 1Tick
            _Timer.Tick += new EventHandler(Timer_Tick);
            _Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int curTime = DateTime.Now.Hour;
            System.Windows.Media.Animation.Storyboard stbLow = (System.Windows.Media.Animation.Storyboard)FindResource("Opacity_Lower");
            System.Windows.Media.Animation.Storyboard stbUp = (System.Windows.Media.Animation.Storyboard)FindResource("Opacity_Upper");
            ImageBrush imgB;
            BeginStoryboard(stbLow);
            if (curTime > 4 && curTime < 17) //5~16시
            {
                imgB = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(curPath + @"D\" + picCnt.ToString() + ".jpg", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
            }
            else if(curTime > 16 && curTime < 22) //17~21시
            {
                imgB = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(curPath + @"S\" + picCnt.ToString() + ".jpg", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
            }
            else //22~4시
            {
                imgB = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(curPath + @"N\" + picCnt.ToString() + ".jpg", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
            }
            if (picCnt == 20)
                picCnt = 1;
            else
                picCnt++;
            grid1.Background = imgB;
            BeginStoryboard(stbUp);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if(NetworkInterface.Login(txtID.Text,txtPass.Password))
            {
                //Login Success
                Setting.ID = txtID.Text;
                MainWindow m = new MainWindow();
                m.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Login Failed","Error",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Animation.Storyboard storyBoard = (System.Windows.Media.Animation.Storyboard)FindResource("Register");
            System.Windows.Media.Animation.Storyboard storyBoard_Rev = (System.Windows.Media.Animation.Storyboard)FindResource("Register_Rev");
            if (!isReg)
            {
                BeginStoryboard(storyBoard);
                isReg = true;
            }
            else
            {
                //Register 처리해주기
                if(NetworkInterface.SignUp(txtID.Text,txtPass.Password,txtName.Text))
                {
                    //Register 성공하면 로그인하라고 해야함
                    MessageBox.Show("등록 성공하였습니다.", "성공", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    //실패하면 다시 하라고 해줘여함
                    MessageBox.Show("이미 있는 계정입니다. 다시 시도해 주세요","오류",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                BeginStoryboard(storyBoard_Rev);
                isReg = false;
            }
        }

        private void lblClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
