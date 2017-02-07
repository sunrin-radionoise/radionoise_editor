using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Code_Editor
{
    /// <summary>
    /// Splash.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Splash : Window
    {
        Timer timer = new Timer();
        int cnt = 0;
        public Splash()
        {
            InitializeComponent();
            lblVersion.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        bool Check_Server()
        {
            return NetworkInterface.Server_Status();
        } 


        private void Timer_Tick(object sender,EventArgs e)
        {
            switch(cnt)
            {
                case 0:
                    lblWorking.Content = "Loading Syntax Module";
                    cnt++;
                    break;
                case 1:
                    lblWorking.Content = "Loading Chatting Module";
                    cnt++;
                    break;
                case 3:
                    lblWorking.Content = "Loading Network Manager";
                    cnt++;
                    break;
                case 7:
                    cnt++;
                    lblWorking.Content = "Try Server Connect";
                    if (!Check_Server())
                    {
                        Setting.OnlineMode = false;
                        //MainWindow m = new MainWindow();
                        //m.Show();
                        //Close();
                        LoginWindow l = new LoginWindow();
                        l.Show();
                        Close();

                        timer.Stop();
                    }
                    else {
                        Setting.OnlineMode = true;
                        lblWorking.Content = "Completed";
                        LoginWindow l = new LoginWindow();
                        l.Show();
                        Close();
                        timer.Stop();
                    }
                    break;
                case 12:
                    break;
                default:
                    cnt++;
                    break;
            }
        }
    }
}
