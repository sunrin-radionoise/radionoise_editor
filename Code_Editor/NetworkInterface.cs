using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Code_Editor
{
    class NetworkInterface
    {
        static string BaseURL = "http://iwin247.net:8080"; //BaseURL
        
        public void Auth(string id, string passwd)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/auth");
        }
        public static void SignUp(string id, string passwd, string name)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/auth/signup");
            Console.WriteLine(req.Address);
            var postData = "id="+id;
            postData += "&passwd="+passwd;
            postData += "&name=" + name;
            var data = Encoding.ASCII.GetBytes(postData);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;
            Console.WriteLine(postData);
            using (var stream = req.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)req.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            MessageBox.Show(responseString);
        }
        public void GetVer()
        {
            HttpWebRequest req;
        }
        public void GetSetting()
        {
            HttpWebRequest req;
        }
        public void GetUpdateFile()
        {
            HttpWebRequest req;
        }
    }
}
