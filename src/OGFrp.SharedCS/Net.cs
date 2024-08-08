using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System.Windows;
using System.Security.Policy;
using System.Windows.Forms;

namespace OGFrp.UI
{
    public class Net
    {
        public static string Get(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            return retString;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <param name="content">Post提交数据内容(utf-8编码的)</param>
        /// <returns></returns>
        public static string Post(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 获取OGFrp用户的访问密钥
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public static string GetAccessToken(string Username, string Password)
        {
            return Post(Api.Server.Val + "/?action=gettoken", "username=" + Username + "&password=" + Password);
        }

        /// <summary>
        /// 获取 OnlymoeFrp 的用户信息
        /// </summary>
        /// <param name="Token">访问密钥</param>
        /// <returns></returns>
        public static string GetUserInfo(string Token)
        {
            return Post(Api.Server.Val + "/?action=getuserinfo", "token=" + Token);
        }

        /// <summary>
        /// 获取 OnlymoeFrp 的节点列表
        /// </summary>
        /// <param name="Token">访问密钥</param>
        /// <returns></returns>
        public static string GetNodes(string Token)
        {
            return Post(Api.Server.Val + "/?action=getnodes", "token=" + Token);
        }

        /// <summary>
        /// 获取 OnlymoeFrp 用户的隧道列表
        /// </summary>
        /// <param name="Token">访问密钥</param>
        /// <returns></returns>
        public static string GetProxies(string Token)
        {
            return Post(Api.Server.Val + "/?action=getproxies", "token=" + Token);
        }

        /// <summary>
        /// 获取可用的 OnlymoeFrp 的api服务器
        /// </summary>
        /// <returns></returns>
        public static string GetApis()
        {
            string apiServer = "";
            string serverDelay = "";
            string[] serverList = new string[0];
            string lsadr = "https://nyu.olmga.cn/olm.txt";
            string dServer = "https://auth.frp.among.moe";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (File.Exists(folderPath + "\\OGFrp\\api.ini"))
            {
                using (StreamReader ReaderObject = new StreamReader(folderPath + "\\OGFrp\\api.ini"))
                {
                    string Line;
                    string serverLists = "";
                    while ((Line = ReaderObject.ReadLine()) != "::end=1")
                    {
                        char[] chars = "[".ToCharArray();
                        if (Line[0] != chars[0])
                        {
                            if (Line.Trim() != "")
                            {
                                serverLists += Line + "\n";
                            }
                        }
                    }
                    try
                    {
                        string serverListss = Get(lsadr).Replace("\r", "").Trim();
                        serverLists += serverListss;
                    } catch { }
                    if (serverLists.Length > 0)
                    {
                        serverList = serverLists.Split('\n').ToArray();
                    }
                    else
                    {
                        try
                        {
                            serverList = Get(lsadr).Replace("\r", "").Trim().Split('\n').ToArray();
                        } catch { }
                    }
                }
            }
            else
            {
                if (Directory.Exists(folderPath + "\\OGFrp") == false)
                {
                    Directory.CreateDirectory(folderPath + "\\OGFrp");
                }
                StreamWriter writer = new StreamWriter(folderPath + "\\OGFrp\\api.ini");
                string content = "[api]\n";
                content += "::end=1";
                writer.Write(content);
                writer.Close();
                try
                {
                    serverList = Get(lsadr).Replace("\r","").Trim().Split('\n').ToArray();
                } catch { }
            }
            try
            {
                string AvailableServers = "";
                foreach (string server in serverList)
                {
                    if (server.Trim() != "")
                    {
                        try
                        {
                            DateTime startTime = DateTime.Now;
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(server.Trim());
                            request.Proxy = null;
                            request.KeepAlive = false;
                            request.Method = "GET";
                            request.ContentType = "application/json; charset=UTF-8";
                            request.AutomaticDecompression = DecompressionMethods.GZip;
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream myResponseStream = response.GetResponseStream();
                            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                            string retString = myStreamReader.ReadToEnd();

                            myStreamReader.Close();
                            myResponseStream.Close();

                            if (response != null)
                            {
                                response.Close();
                            }
                            if (request != null)
                            {
                                request.Abort();
                            }
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                DateTime endTime = DateTime.Now;
                                serverDelay += Convert.ToInt32((endTime - startTime).TotalMilliseconds).ToString() + "\n";
                                AvailableServers += server.Trim() + "\n";
                            }
                        }
                        catch { }
                    }
                }
                if (!string.IsNullOrEmpty(AvailableServers))
                {
                    AvailableServers = AvailableServers.Substring(0, AvailableServers.Length - 1);
                    serverDelay = serverDelay.Substring(0, serverDelay.Length - 1);
                    string[] AvailableServerss = AvailableServers.Split('\n').ToArray();
                    string[] serverssDelay = serverDelay.Split('\n').ToArray();
                    var serversDelay = Array.ConvertAll(serverssDelay, s => int.TryParse(s, out int i) ? i : 0);
                    int minIndex = 0;
                    string minIndexes = "";
                    while (minIndex != -1)
                    {
                        if (minIndex + 1 <= serversDelay.Length)
                        {
                            minIndex = Array.IndexOf(serversDelay, serversDelay.Min(), minIndex);
                            if (minIndex != -1)
                            {
                                minIndexes += minIndex.ToString() + "\n";
                                minIndex = minIndex + 1;
                            } else
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                    }
                    minIndexes = minIndexes.Substring(0, minIndexes.Length - 1);
                    string[] minIndexess = minIndexes.Split('\n').ToArray();
                    var minIndexesss = Array.ConvertAll(minIndexess, s => int.TryParse(s, out int i) ? i : 0);
                    Random ran = new Random();
                    int n = ran.Next(minIndexesss.Length - 1);
                    //System.Windows.Forms.MessageBox.Show(AvailableServers.ToString());
                    //System.Windows.Forms.MessageBox.Show(serverDelay.ToString());
                    //System.Windows.Forms.MessageBox.Show(minIndexes.ToString());
                    //System.Windows.Forms.MessageBox.Show(minIndexesss[n].ToString());
                    apiServer = AvailableServerss[minIndexesss[n]];
                }
                Api.Servers.Val = AvailableServers;
                Api.Server.Val = apiServer.Trim();
            }
            catch { }
            if (string.IsNullOrEmpty(apiServer))
            {
                apiServer = dServer;
                Api.Servers.Val = apiServer + "\n";
                Api.Server.Val = apiServer;
            }
            return apiServer.Trim();
        }

        public int Download(string source, string localPath, bool forceDownload = false)
        {
            if (forceDownload)
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
                return 0;
            }
            else if (!File.Exists(localPath))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
