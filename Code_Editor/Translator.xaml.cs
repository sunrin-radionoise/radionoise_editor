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
    /// Translator.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Translator : Window
    {
        private string base_type = "b";
        private string trans_type = "b";
        public Translator()
        {
            InitializeComponent();
        }

        private void Base_TextChanged(object sender, TextChangedEventArgs e)
        {
            Trans.Text = Translate(base_type,Base.Text,trans_type);
        }

        private string Translate(string basetype, string baset, string type)
        {
            int temp = 0;
            string rtnval = "";
            switch (basetype)
            {
                case "b":
                    temp = Convert.ToInt32(baset, 2);
                    break;
                case "o":
                    temp = Convert.ToInt32(baset, 8);
                    break;
                case "d":
                    temp = Convert.ToInt32(baset);
                    break;
                case "h":
                    temp = Convert.ToInt32(baset, 16);
                    break;
            }
            //String a => Convert.Int32(a) -> Convert.ToType(a) -> 리턴
            switch (type)
            {
                case "b":
                    rtnval = Convert.ToString(temp,2);
                    break;
                case "o":
                    rtnval = Convert.ToString(temp, 8);
                    break;
                case "d":
                    rtnval = Convert.ToString(temp, 10);
                    break;
                case "h":
                    rtnval = Convert.ToString(temp, 16);
                    break;
            }
            return rtnval;
        }

        private void tCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
