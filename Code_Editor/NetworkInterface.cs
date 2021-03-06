﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
namespace Code_Editor
{
    class NetworkInterface
    {
        /// <summary>
        /// Base URL입니다.
        /// </summary>
        static string BaseURL = "http://radionoise.iwin247.kr:80";
        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="id">로그인할 ID</param>
        /// <param name="passwd">로그인할 PW</param>
        public static bool Login(string id, string passwd)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/auth/signup");
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
            catch(WebException e) //HTTP 400 Error : ID/PW Error Or Not Found Or param missing
            {
                Console.WriteLine(((HttpWebResponse)e.Response).StatusCode);
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
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/auth/signin");
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
        /// <summary>
        /// Current Program Version을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static bool GetVer()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/version");
            Console.WriteLine(req.Address);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
                return true; //Working
            }
            catch (Exception) //Cannot GET
            {
                return false; //Not Working
            }
        }
        public string GetSetting(string token)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/setting/" + token);
            Console.WriteLine(req.Address);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch(Exception)
            {
                return false.ToString();
            }
        }
        public void GetUpdateFile()
        {
           
        }
        public bool AttachFacebook(string userToken)
        {
            //GET URL : BaseURL + auth/fb/token?access_token= + Token
            //return success/fail
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL +"/auth/fb/token"+SocialTokens.FacebookToken);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Server_Status() //GET으로 서버가 값을 반환하는지를 판단한다.
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/version");
            Console.WriteLine(req.Address);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
                return true; //Working
            }
            catch (Exception) //Cannot GET
            {
                return false; //Not Working
            }
        }
        public static string GetTextEditing(string Filename)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BaseURL + "/" + Filename);
            Console.WriteLine(req.Address);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var response = (HttpWebResponse)req.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
                return "a"; //Working
            }
            catch (Exception) //Cannot GET
            {
                return "b"; //Not Working
            }
        }
        public static List<GItem> GetRepositoryFiles()
        {
            return null; 
        }
    }
}
