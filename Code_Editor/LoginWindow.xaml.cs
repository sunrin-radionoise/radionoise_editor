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
using System.Windows.Shapes;

namespace Code_Editor
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static bool isReg = false;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Server POST : Login
             * Login 완료되면 Setting.ID에 로그인 성공한 ID를 입력해야 한다.
             */
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
                BeginStoryboard(storyBoard_Rev);
                isReg = false;
            }
        }
    }
}
