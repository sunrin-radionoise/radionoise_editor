using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Editor
{
    class OpponentManager
    {
        /// <summary>
        /// Chatting Opponent를 담은 List입니다.
        /// </summary>
        public static List<string> Opponent;
        /// <summary>
        /// 대화 상대를 추가합니다.
        /// </summary>
        /// <param name="oppoName">추가할 상대 이름</param>
        /// <returns>성공 여부를 반환합니다.</returns>
        public bool Add_Oppo(string oppoName)
        {
            try
            {
                Opponent.Add(oppoName);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 대화 상대 List를 가져옵니다.
        /// </summary>
        /// <returns>대화 상대가 추가되어있는 Opponent List를 가져옵니다.</returns>
        public List<string> Get_Oppo()
        {
            return Opponent;
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
                Opponent.Remove(oppoName);
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
                Opponent.Remove(orgOppo);
                Opponent.Add(changeOppo);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
