﻿using System;
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
            InitializeContents();
        }

        private void InitializeContents()
        {
            lblpath.Content = Setting.ImagePath;
            ColorID.Text = Setting.ColorID;
            Opacity_slider.Value = Setting.BackOpacity;
            lblFont.Content = Setting.Font + ", " + Setting.FontSize.ToString();
            if (Setting.Color)
                chkColor.IsChecked = true;
            else
                chkColor.IsChecked = false;
        }

        private void SettingDialog_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            /*
             * 설정 동기화를 변경함. Setting.Sync 옵션을 변경해 줌.
             */
            if (Setting.Sync)
                Setting.Sync = false;
            else
                Setting.Sync = true;
        }

        private void chkColor_Checked(object sender, RoutedEventArgs e)
        {
            /*
             * 체크되면 Color를 사용한다는 거니까 MainWindow의 CodeEditor에 반영되도록 Setting.Color를 True로 설정해준다.
             */
            if (Convert.ToBoolean(chkColor.IsChecked))
                Setting.Color = true;
            else
                Setting.Color = false;
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Image Select Button : openFileDialog 이용한다. Setting.ImagePath와 연결된다.
             */
            MessageBox.Show("1024*768 이상의 해상도의 이미지를 추천합니다.","안내",MessageBoxButton.OK,MessageBoxImage.Information);
            var digOpen = new System.Windows.Forms.OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png|*.bmp|*.bmp",
                Title = "Select Image File"
            };
            if(digOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Setting.ImagePath = digOpen.FileName;
                lblpath.Content = Setting.ImagePath;
                Setting.Color = false;
            }
        }

        private void SettingDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Opacity_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Setting.BackOpacity = (int)Opacity_slider.Value;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Setting.ColorID = ColorID.Text;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(((ComboBoxItem)Combo_Auto.SelectedItem).Name.ToString())
            {
                case "Save_Off":
                    MessageBox.Show("꺼짐");
                    break;
                case "Save_OM":
                    MessageBox.Show("1");
                    break;
                case "Save_FM":
                    MessageBox.Show("5");
                    break;
                case "Save_TM":
                    MessageBox.Show("10");
                    break;
            }
        }

        private void btnFont_Click(object sender, RoutedEventArgs e)
        {
            var f = new System.Windows.Forms.FontDialog()
            {
                ShowApply = false,
                ShowColor = false,
                ShowEffects = false,
                ShowHelp = false,
                FontMustExist = true,
                AllowVerticalFonts = false
            };
            if(f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Setting.Font = f.Font.Name.ToString();
                Setting.FontSize = Convert.ToInt32(f.Font.Size);
                lblFont.Content = Setting.Font + ", " + Setting.FontSize.ToString();
            }
        }
    }
}
