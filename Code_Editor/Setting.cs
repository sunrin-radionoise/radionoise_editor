using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Code_Editor
{

    class Setting
    {
        /* INI FIELD CONFIG TEMPLATE
         * Setting.ini
         * [Font]
         * Font=Consolas
         * FontSize=13
         * [Background]
         * Color=false
         * ImagePath=C:\blah\blah.png
         * [Account]
         * ID=ayh0729
         * PW=asdf1234
         * Sync=false
         */
        #region Setting_Field
        public static string Font { get; set; }
        public static int FontSize { get; set; }
        public static bool Color { get; set; }
        public static string ImagePath { get; set; }
        public static string ID { get; set; }
        public static string PW { get; set; }
        public static bool Sync { get; set; }
        #endregion
        public static string setting_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Setting.ini";
    }
    class SettingManager
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public void Load_Setting()
        {
            StringBuilder temp = new StringBuilder(255);
            int ret = GetPrivateProfileString("Font", "Font", "", temp, 255, Setting.setting_path);
            MessageBox.Show(temp.ToString());
        }

        public void Save_Setting()
        {

        }
    }
}
