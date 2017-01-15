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
        /// <summary>
        /// Base URL입니다.
        /// </summary>
        static string BaseURL = "http://iwin247.net:8080"; //BaseURL
        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="id">로그인할 ID</param>
        /// <param name="passwd">로그인할 PW</param>
        public static bool Login(string id, string passwd)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/auth/signin");
            Console.WriteLine(req.Address);
            var postData = "id=" + id;
            postData += "&passwd=" + passwd;
            var data = Encoding.ASCII.GetBytes(postData);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;
            Console.WriteLine(postData);
            try
            {
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
                return true;
            }
            catch(Exception) //HTTP 400 Error : ID/PW Error Or Not Found Or param missing
            {
                return false;
            }
            
        }
        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <param name="id">가입할 ID</param>
        /// <param name="passwd">가입할 PW</param>
        /// <param name="name">가입할 이름</param>
        public static bool SignUp(string id, string passwd, string name)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/auth/signup");
            Console.WriteLine(req.Address);
            var postData = "id=" + id;
            postData += "&passwd=" + passwd;
            postData += "&name=" + name;
            var data = Encoding.ASCII.GetBytes(postData);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;
            Console.WriteLine(postData);
            try
            {
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
                return true;
            }
            catch(Exception)//HTTP 400 : Already exist or param missing
            {
                return false;
            }
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
