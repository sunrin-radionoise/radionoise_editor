using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Editor
{
    class Account
    {
        private static string id;
        private static string pw;
        private static string token;
        public static string ID { get { return id; } set { id = value; } }
        public static string PW { get { return pw; } set { pw = value; } }
        public static string Token { get { return token; } set { token = value; } }
    }
}
