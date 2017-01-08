using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Code_Editor
{
    class Setting
    {
        /* TODO : Add Setting Field
         * Font
         * Background Image
         * Account
         */
        public static string Font { get; set; }
        public static string BackImage { get; set; }
        public static string Account { get; set; }
        private static string setting_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Settings.xml";
        public void Init_Setting()
        {
            //Load File & Apply Settings
            
        }
    }
}
