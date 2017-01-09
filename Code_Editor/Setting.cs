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
        public static string StretchType { get; set; }
        public static string Account { get; set; }
        private static string setting_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Settings.xml";
        public void Init_Setting()
        {
            //Load File & Apply Settings
            StreamReader sr = new StreamReader(setting_path);
            string str = sr.ReadToEnd();
            string[] split = str.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //각각 첫줄부터 Font, Path, Stretch Type
            Font = split[0];
            BackImage = split[1];
            StretchType = split[2];
        }
        public void Sync_Setting(bool Get)
        {
            if(Get) //Sync를 받아오는 부분 -> Server에서 받아온다.
            {
                
            }
            else //Sync를 보내는 부분 -> Server에 저장한다.
            {

            }
        }
    }
}
