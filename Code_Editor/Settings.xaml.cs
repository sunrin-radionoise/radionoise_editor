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
    /// Settings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void SettingDialog_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            /*
             * 설정 동기화를 변경함. Setting.Sync 옵션을 변경해 줌.
             */
        }

        private void chkColor_Checked(object sender, RoutedEventArgs e)
        {
            /*
             * 체크되면 Color를 사용한다는 거니까 MainWindow의 CodeEditor에 반영되도록 Setting.Color를 True로 설정해준다.
             */
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Image Select Button : openFileDialog 이용한다. Setting.ImagePath와 연결된다.
             */
        }
    }
}
