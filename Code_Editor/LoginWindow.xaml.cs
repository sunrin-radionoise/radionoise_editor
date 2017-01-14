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
            //투명도 낮춰준다.
            //이미지 바꾼다.
            //투명도 올려준다.
            //cnt가 20이 되면 1로 바꿔준다.
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
            /*
             * Server POST : Login
             * Login 완료되면 Setting.ID에 로그인 성공한 ID를 입력해야 한다.
             */
            if(txtID.Text == "ayh0729" && txtPass.Password == "asdf1234")
            {
                //Login Success
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
                NetworkInterface.SignUp(txtID.Text,txtPass.Password,txtName.Text);
                BeginStoryboard(storyBoard_Rev);
                isReg = false;
            }
        }
    }
}
