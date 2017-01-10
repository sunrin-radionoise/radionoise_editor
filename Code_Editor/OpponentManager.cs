using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Code_Editor
{
    /// <summary>
    /// Chating Opponent를 담는 class입니다.
    /// </summary>
    class Opponent
    {
        /// <summary>
        /// Chatting Opponent를 담은 List입니다.
        /// </summary>
        public static List<string> OppoList = new List<string> { "", };
    }
    /// <summary>
    /// 
    /// </summary>
    class OpponentManager
    {
        private static string oppo_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Chat.settings";
        /// <summary>
        /// 대화 상대를 추가합니다.
        /// </summary>
        /// <param name="oppoName">추가할 상대 이름</param>
        /// <returns>성공 여부를 반환합니다.</returns>
        public bool Add_Oppo(string oppoName)
        {
            try
            {
                Opponent.OppoList.Add(oppoName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 대화 상대를 제거합니다.
        /// </summary>
        /// <param name="oppoName">제거할 상대 이름</param>
        /// <returns>성공 여부를 반환합니다.</returns>
        public bool Del_Oppo(string oppoName)
        {
            try
            {
                Opponent.OppoList.Remove(oppoName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 대화 상대 이름을 수정합니다.
        /// </summary>
        /// <param name="orgOppo">수정할 원래 상대 이름</param>
        /// <param name="changeOppo">수정할 이름</param>
        /// <returns>성공 여부를 반환합니다.</returns>
        public bool Edit_Oppo(string orgOppo, string changeOppo)
        {
            try
            {
                Opponent.OppoList.Remove(orgOppo);
                Opponent.OppoList.Add(changeOppo);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Opponent 초기화 작업. Opponent 사용하고싶으면 먼저 호출해주어야 한다.
        /// </summary>
        public void Init_Oppo()
        {
            //현재 프로세스가 실행되는 폴더(프로그램 실행폴더)의 경로를 가져온다.
            string content;
            string[] temp_oppo;
            var sr = new StreamReader(oppo_path);
            content = sr.ReadToEnd();
            sr.Close();
            temp_oppo = content.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string tmp in temp_oppo)
            {
                Opponent.OppoList.Add(tmp);
            }
        }
        /// <summary>
        /// Opponent를 Chat.settings에 저장한다.
        /// 종료할 때 호출해 주어야 한다.
        /// </summary>
        public void Save_Oppo()
        {
            var sw = new StreamWriter(oppo_path);
            foreach(string tmp in Opponent.OppoList)
            {
                sw.WriteLine(tmp);
            }
            sw.Close();
        }
    }
}
