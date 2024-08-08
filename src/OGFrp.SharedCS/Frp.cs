using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using static Microsoft.VisualBasic.Interaction;

namespace OGFrp.UI
{
    public class Frp
    {
        Net Net = new Net();
        Config Config = new Config();
        Userinf Userinfo = new Userinf();
        Api Api = new Api();

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        public int DownloadFrpc()
        {
            try
            {
                Net.Download("https://client.ogfrp.cn/frpc/frpc_windows_amd64.exe", path + "\\frpc.exe");
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public int reDownloadFrpc()
        {
            try
            {
                Net.Download("https://client.ogfrp.cn/frpc/frpc_windows_amd64.exe", path + "\\frpc.exe", true);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0; ;
        }

        /// <summary>
        /// 将OGFrp节点IP转换成ID
        /// </summary>
        /// <param name="server">节点IP</param>
        /// <param name="token">OGFrp用户token</param>
        /// <returns></returns>
        public int serverToId(string server, string token)
        {
            FrpServer frpServer = new FrpServer();
            FrpServerModel[] frpServers = frpServer.FrpsServerList(Net.Get(Api.Server.Val + "/?action=getnodes&token=" + token)).ToArray();
            for (int i = 0; i < frpServers.Length; i++)
            {
                if (frpServers[i].ID == server)
                {
                    return int.Parse(frpServers[i].ID);
                }
            }
            return -1;
        }

        /// <summary>
        /// 启动frpc
        /// </summary>
        /// <param name="token">OGFrp用户token</param>
        /// <param name="server">OGFrp的节点ID</param>
        /// <returns></returns>
        public int launchFrpc(string token, int server)
        {
            try
            {
                UTF8Encoding utf8 = new UTF8Encoding(false);
                File.WriteAllText(Config.FolderPath + "\\frpc.ini", Net.Get(Api.Server.Val + "/?action=getconfig&token=" + token + "&node=" + server.ToString()), utf8);
                Interaction.Shell(Config.FolderPath + "\\frpc.exe -c \"" + Config.FolderPath + "\\frpc.ini\"", AppWinStyle.NormalFocus);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 启动frpc
        /// </summary>
        /// <param name="token">OGFrp用户token</param>
        /// <param name="server">OGFrp节点IP</param>
        /// <returns></returns>
        public int launchFrpc(string token, string server)
        {
            try
            {
                string frpciniurl = "token=" + token + "&node=" + serverToId(server, token);
                UTF8Encoding utf8 = new UTF8Encoding(false);
                File.WriteAllText(Config.FolderPath + "\\frpc.ini", Net.Post(Api.Server.Val + "/?action=getconfig", frpciniurl), utf8);
                Interaction.Shell(Environment.CurrentDirectory + "\\frpc.exe -c \"" + Config.FolderPath + "\\frpc.ini\"", AppWinStyle.NormalFocus);
            }
            catch (Exception ex)
            {
                MsgBox("Failure at\n" + ex.ToString(), MsgBoxStyle.Critical, "OGFrp");
                return -1;
            }
            return 0;
        }
    }
}
