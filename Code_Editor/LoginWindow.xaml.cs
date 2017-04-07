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
        public string Current_Page = "Main";
        private static bool isReg = false;
        int picCnt = 0;
        private NetworkInterface _NetworkInterface = new NetworkInterface();
        int curTime = DateTime.Now.Hour;
        static string curPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Resources\Back\";
        System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void lblClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            //메인화면의 로그인 버튼을 누른 것이다.
            Storyboard storyBoard = (Storyboard)FindResource("DMain");
            Storyboard storyBoard2 = (Storyboard)FindResource("ULogin");
            Current_Page = "Login";
            BeginStoryboard(storyBoard);
            BeginStoryboard(storyBoard2);
            BackButton.IsHitTestVisible = true;
        }
        /// <summary>
        /// 로그인화면의 로그인버튼 누를때 이벤트이다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            //로그인화면의 로그인버튼을 누른것이다.
            //Storyboard s1 = (Storyboard)FindResource("DLogin");
            //Storyboard s2 = (Storyboard)FindResource("AMain");
            //BeginStoryboard(s1);
            //BeginStoryboard(s2);
            if(NetworkInterface.Login(LoginID.Text, LoginPW.Text))
            {
                MainWindow m = new MainWindow();
                m.Show();
            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다.","로그인",MessageBoxButton.OK,MessageBoxImage.Asterisk);
            }
        }

        private void LblRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            //회원가입 화면으로 넘어가는 것이다.
            Storyboard s1 = (Storyboard)FindResource("DMain");
            Storyboard s2 = (Storyboard)FindResource("UReg");
            Current_Page = "Reg";
            BeginStoryboard(s1);
            BeginStoryboard(s2);
            BackButton.IsHitTestVisible = true;
        }

        private void BackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard dl = (Storyboard)FindResource("DLogin");
            Storyboard dr = (Storyboard)FindResource("DReg");
            Storyboard um = (Storyboard)FindResource("AMain");
            switch(Current_Page)
            {
                case "Main":
                    BackButton.IsHitTestVisible = false;
                    break;
                case "Login":
                    BeginStoryboard(dl);
                    BeginStoryboard(um);
                    Current_Page = "Main";
                    BackButton.IsHitTestVisible = false;
                    break;
                case "Reg":
                    BeginStoryboard(dr);
                    BeginStoryboard(um);
                    Current_Page = "Main";
                    BackButton.IsHitTestVisible = false;
                    break;
            }
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            if(NetworkInterface.SignUp(Mail.Text,Passwd.Text,Nick.Text))
            {
                MessageBox.Show("가입에 성공하였습니다.", "회원 가입", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("이미 존재하는 계정입니다.", "회원 가입", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
