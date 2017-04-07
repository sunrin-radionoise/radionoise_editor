using Facebook;
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
using System.Windows.Media.Animation;
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
              
            }
        }

        private void lblClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Facebook Login Button
            var fb = new SocialWindow("fb");
            fb.Show();
            Console.Write(SocialTokens.FacebookToken);
        }

        private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            Storyboard storyBoard = (Storyboard)FindResource("DMain");
            Storyboard storyBoard2 = (Storyboard)FindResource("ULogin");
            BeginStoryboard(storyBoard);
            
            BeginStoryboard(storyBoard2);
        }
        /// <summary>
        /// 로그인화면의 로그인버튼 누를때 이벤트이다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            //로그인화면의 로그인버튼을 누른것이다.
            Storyboard s1 = (Storyboard)FindResource("DLogin");
            Storyboard s2 = (Storyboard)FindResource("AMain");
            BeginStoryboard(s1);
            BeginStoryboard(s2);
        }

        private void LblRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard s1 = (Storyboard)FindResource("DMain");
            Storyboard s2 = (Storyboard)FindResource("UReg");
            BeginStoryboard(s1);
            BeginStoryboard(s2);
        }
    }
}
