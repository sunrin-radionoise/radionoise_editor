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
            try
            {
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
                        rtnval = Convert.ToString(temp, 2);
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
            }
            catch(Exception)
            {
                rtnval = "";
            }
            return rtnval;
        }

        private void tCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Base != null && Trans != null)
            {
                Trans.Text = Translate(base_type, Base.Text, trans_type);
            }
        }

        private void bCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Base!=null&&Trans!=null)
            {
                Trans.Text = Translate(base_type, Base.Text, trans_type);
            }
        }

        private void BBin_Selected(object sender, RoutedEventArgs e)
        {
            base_type = "b";
        }

        private void BOct_Selected(object sender, RoutedEventArgs e)
        {
            base_type = "o";
        }

        private void BDec_Selected(object sender, RoutedEventArgs e)
        {
            base_type = "d";
        }

        private void BHex_Selected(object sender, RoutedEventArgs e)
        {
            base_type = "h";
        }

        private void TBin_Selected(object sender, RoutedEventArgs e)
        {
            trans_type = "b";
        }

        private void TOct_Selected(object sender, RoutedEventArgs e)
        {
            trans_type = "o";
        }

        private void TDec_Selected(object sender, RoutedEventArgs e)
        {
            trans_type = "d";
        }

        private void THex_Selected(object sender, RoutedEventArgs e)
        {
            trans_type = "h";
        }

        private void RGB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RGB != null && HexC != null)
            {
                try
                {
                    HexC.Text = "";
                    string ToHex = "";
                    string[] RGBs = RGB.Text.Split(',');
                    int tmp;
                    for (int i = 0; i < 3; i++)
                    {
                        tmp = Convert.ToInt32(RGBs[i]);
                        ToHex = Convert.ToString(tmp, 16);
                        HexC.Text += ToHex;
                    }
                }
                catch (Exception)
                {
                    HexC.Text = "";
                }
            }
        }
    }
}
