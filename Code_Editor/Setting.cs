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
         * Opacity=100
         * ColorID=Black
         * [Account]
         * ID=ayh0729
         * PW=asdf1234
         * Sync=false
         * AutoLogin=False
         * //Token=asdfasdfasdfasdf
         * //Social=Facebook/Twitter/Github/Google?
         * [File]
         * AutoSave=1/5/10
         */
        #region Setting_Field
        public static List<string> OppoList = new List<string> { "", };
        public static string Font { get; set; }
        public static int FontSize { get; set; }
        public static bool Color { get; set; }
        public static string ImagePath { get; set; }
        public static int BackOpacity { get; set; }
        public static string ColorID { get; set; }
        public static string ID { get; set; }
        public static string PW { get; set; }
        public static bool Sync { get; set; }
        public static bool AutoLogin { get; set; }
        public static bool OnlineMode { get; set; }
        public static int SaveTime { get; set; }
        //public static List<string> Colors;
        #endregion
        public static readonly string setting_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Setting.ini";
    }
    class SettingManager
    {
#region INI_APIS
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        private string Read_ini(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int ret = GetPrivateProfileString(section, key, "", temp, 255, Setting.setting_path);
            return temp.ToString();
        }
        private void Write_ini(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Setting.setting_path);
        }
#endregion
        public void Load_Setting()
        {
            //Setting에 Load한다.
            Setting.Font = Read_ini("Font", "Font");
            Setting.FontSize = Convert.ToInt32(Read_ini("Font","FontSize"));
            Setting.Color = Convert.ToBoolean(Read_ini("Background", "Color"));
            Setting.ImagePath = Read_ini("Background","ImagePath");
            Setting.BackOpacity = Convert.ToInt32(Read_ini("Background","Opacity"));
            Setting.ColorID = Read_ini("Background", "ColorID");
            Setting.ID = Read_ini("Account","ID");
            Setting.PW = Read_ini("Account", "PW");
            Setting.Sync = Convert.ToBoolean(Read_ini("Account", "Sync"));
            Setting.AutoLogin = Convert.ToBoolean(Read_ini("Account", "autoLogin"));
            Setting.SaveTime = Convert.ToInt32(Read_ini("File", "AutoSave"));
        }

        public void Save_Setting()
        {
            //Setting.ini에 저장한다.
            Write_ini("Font", "Font", Setting.Font);
            Write_ini("Font", "FontSize", Setting.FontSize.ToString());
            Write_ini("Background", "Color", Setting.Color.ToString());
            Write_ini("Background", "ImagePath", Setting.ImagePath);
            Write_ini("Bakcground", "ColorID", Setting.ColorID);
            Write_ini("Account", "ID", Setting.ID);
            Write_ini("Account", "PW", Setting.PW);
            Write_ini("Account", "Sync", Setting.Sync.ToString());
            Write_ini("Account", "AutoLogin", Setting.AutoLogin.ToString());
            Write_ini("File", "AutoSave", Setting.SaveTime.ToString());
        }
    }
}
