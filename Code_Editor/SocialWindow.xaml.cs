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
    /// SocialWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SocialWindow : Window
    {
        
        readonly string FacebookAuthUri = "https://www.facebook.com/dialog/oauth?client_id=1898081023756082&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token";
        public SocialWindow(string type)
        {
            InitializeComponent();
            switch(type)
            {
                case "fb":
                    WBrowser.Navigate(new Uri(FacebookAuthUri,UriKind.Absolute));
                    break;
            }
        }

        private void WBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if(e.Uri.ToString().StartsWith("https://www.facebook.com/connect/login_success.html"))
            {
                SocialTokens.FacebookToken = e.Uri.Fragment.Split('&')[0].Replace("#access_token=","");
            }
        }
    }
}
