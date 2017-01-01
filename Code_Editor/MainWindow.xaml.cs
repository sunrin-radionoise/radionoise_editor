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

namespace Code_Editor
{
    
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Client Socket;   
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Socket = new Client("http://iwin247.net:8080");
            }
            catch (Exception)
            {
                Socket = null;
            }
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
            if((e.Key == Key.LeftShift || e.Key == Key.RightShift) && (e.Key == Key.Enter))
            {
                SendTXT.Text += "\r\n";
            }
            else if(e.Key == Key.Enter)
            {

            }
        }
    }
}
