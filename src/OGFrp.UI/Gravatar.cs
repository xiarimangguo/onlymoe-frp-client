using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OGFrp.UI
{
    public class Gravatar
    {
        public static string ts;

        private static string GetMD5(string sDataIn)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        public static string FolderPath = Config.FolderPath + "\\head_imgs";

        /// <summary>
        /// 获取Gravatar头像
        /// </summary>
        /// <param name="email">邮箱地址</param>
        public static void getImage(string email)
        {
            bool isContains = email.ToLower().Contains("@".ToLower());
            string mail = "";
            string url = "";
            if (!isContains)
            {
                JObject res = (JObject)JsonConvert.DeserializeObject(Net.GetUserInfo(Userinf.Usertoken.Val));
                mail = res["email"].ToString();
            }
            else
            {
                mail = email;
            }
            bool isContainsQQ = mail.ToLower().Contains("@qq.com".ToLower());
            if (Directory.Exists(FolderPath) == false)
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (!isContainsQQ)
            {
                url = "https://cdn.zerodream.net/images/gravatar/?id=" + GetMD5(mail);
            }
            else
            {
                string[] mails = mail.Split('@');
                url = "https://q1.qlogo.cn/g?b=qq&nk=" + mails[0].ToString() + "&s=640";
            }
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadFile(url, FolderPath + "\\" + email + ".png");
            return;
        }
    }
}
