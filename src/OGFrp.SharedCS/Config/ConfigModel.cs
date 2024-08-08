using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OGFrp.UI
{
    /// <summary>
    /// ConfigModel
    /// </summary>
    public class ConfigModel
    {
        /// <summary>
        /// 设置：设置名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设置：记录值
        /// </summary>
        public string Val { get; set; }
    }

    /// <summary>
    /// UserinfModel
    /// </summary>
    public class UserinfModel
    {
        /// <summary>
        /// 用户信息：设置名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户信息：记录值
        /// </summary>
        public string Val { get; set; }
    }

    public class NodeModel
    {
        /// <summary>
        /// 节点信息：设置名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 节点信息：记录值
        /// </summary>
        public string Val { get; set; }
    }
    public class NodeModelInt
    {
        /// <summary>
        /// 节点信息：设置名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 节点信息：记录值
        /// </summary>
        public int Val { get; set; }
    }
    public class ApiModel
    {
        /// <summary>
        /// Api：设置名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Api：记录值
        /// </summary>
        public string Val { get; set; }
    }
    public partial class Config
    {
        /// <summary>
        /// 设置：语言
        /// </summary>
        public ConfigModel Lang = new ConfigModel
        {
            Name = "Lang",
            Val = "zh_cn"
        };

        /// <summary>
        /// 设置：用户名
        /// </summary>
        public ConfigModel Username = new ConfigModel
        {
            Name = "Username"
        };

        /// <summary>
        /// 设置：密码
        /// </summary>
        public ConfigModel Password = new ConfigModel
        {
            Name = "Password"
        };

        /// <summary>
        /// 设置：记住密码
        /// </summary>
        public ConfigModel RmbPsw = new ConfigModel
        {
            Name = "RmbPsw"
        };

        /// <summary>
        /// 设置：Frpc启动模式
        /// </summary>
        public ConfigModel FrpcLaunchMode = new ConfigModel
        {
            Name = "FrpcLaunchMode",
            Val = "proxy"
        };

        public ConfigModel Theme = new ConfigModel
        {
            Name = "Theme",
            Val = "System"
        };
    }
    public class Userinf
    {
        /// <summary>
        /// 用户信息：用户名
        /// </summary>
        public static UserinfModel Username = new UserinfModel
        {
            Name = "Username"
        };

        /// <summary>
        /// 用户信息：uid
        /// </summary>
        public static UserinfModel Userid = new UserinfModel
        {
            Name = "Userid"
        };

        /// <summary>
        /// 用户信息：访问密钥
        /// </summary>
        public static UserinfModel Usertoken = new UserinfModel
        {
            Name = "Usertoken"
        };

        /// <summary>
        /// 用户信息：邮箱
        /// </summary>
        public static UserinfModel Usermail = new UserinfModel
        {
            Name = "Usermail"
        };

        /// <summary>
        /// 用户信息：昵称
        /// </summary>
        public static UserinfModel Usernick = new UserinfModel
        {
            Name = "Usernick"
        };

        /// <summary>
        /// 用户信息：用户组
        /// </summary>
        public static UserinfModel Usergroup = new UserinfModel
        {
            Name = "Usergroup"
        };

        /// <summary>
        /// 用户信息：今日流量
        /// </summary>
        public static UserinfModel TodayTraffic = new UserinfModel
        {
            Name = "TodayTraffic"
        };

        /// <summary>
        /// 用户信息：剩余流量
        /// </summary>
        public static UserinfModel TotalTraffic = new UserinfModel
        {
            Name = "TotalTraffic"
        };
    }
    public class Api
    {
        /// <summary>
        /// Api：可用的 OnlymoeFrp API 服务器列表
        /// </summary>
        public static ApiModel Servers = new ApiModel
        {
            Name = "Servers"
        };
        /// <summary>
        /// Api：当前使用的 OnlymoeFrp API 服务器
        /// </summary>
        public static ApiModel Server = new ApiModel
        {
            Name = "Server"
        };
    }

    public partial class Node
    {
        /// <summary>
        /// 节点信息：id
        /// </summary>
        public static NodeModelInt id = new NodeModelInt
        {
            Name = "id"
        };

        /// <summary>
        /// 节点信息：名称
        /// </summary>
        public static NodeModel name = new NodeModel
        {
            Name = "name"
        };

        /// <summary>
        /// 节点信息：简介
        /// </summary>
        public static NodeModel info = new NodeModel
        {
            Name = "info"
        };

        /// <summary>
        /// 节点信息：地址
        /// </summary>
        public static NodeModel adr = new NodeModel
        {
            Name = "adr"
        };

        /// <summary>
        /// 节点信息：状态
        /// </summary>
        public static NodeModelInt status = new NodeModelInt
        {
            Name = "status"
        };
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">节点id</param>
        /// <param name="name">节点名称</param>
        /// <param name="info">节点简介</param>
        /// <param name="adr">节点地址</param>
        /// <param name="status">节点状态</param>
        public Node(int id, string name, string info, string adr, int status)
        {
            Node.id.Val = id;
            Node.name.Val = name;
            Node.info.Val = info;
            Node.adr.Val = adr;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">节点id</param>
        /// <param name="name">节点名称</param>
        /// <param name="adr">节点地址</param>
        /// <param name="status">节点状态</param>
        public Node(int id, string name, string adr, int status)
        {
            Node.id.Val = id;
            Node.name.Val = name;
            Node.adr.Val = adr;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="info">节点简介</param>
        /// <param name="adr">节点地址</param>
        /// <param name="status">节点状态</param>
        public Node(string name, string info, string adr, int status)
        {
            Node.name.Val = name;
            Node.info.Val = info;
            Node.adr.Val = adr;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">节点id</param>
        /// <param name="name">节点名称</param>
        /// <param name="status">节点状态</param>
        public Node(int id, string name, int status)
        {
            Node.id.Val = id;
            Node.name.Val = name;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="adr">节点地址</param>
        /// <param name="status">节点状态</param>
        public Node(string name, string adr, int status)
        {
            Node.name.Val = name;
            Node.adr.Val = adr;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">节点id</param>
        /// <param name="status">节点状态</param>
        public Node(int id, int status)
        {
            Node.id.Val = id;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="status">节点状态</param>
        public Node(string name, int status)
        {
            Node.name.Val = name;
            Node.status.Val = status;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">节点id</param>
        public Node(int id)
        {
            Node.id.Val = id;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public Node(){
            Node.id.Val = 0;
        }
    }
    public class Nodes
    {
        /// <summary>
        /// 获取单个节点对象
        /// </summary>
        /// <param name="n">节点id</param>
        public static Node Get(int n) {
            for (int i = 0; i < storageIndex.Count; i++)
            {
                if (string.Equals(storageIndex[i].ToString(), n.ToString()))
                {
                    return (Node)storage[i];
                }
            }
            return new Node();
        }
        /// <summary>
        /// 设置单个节点对象
        /// </summary>
        /// <param name="n">单个节点对象</param>
        public static void Set(Node n) 
        {
            if (Node.id.Val == null)
            {
                return;
            }
            int i = Node.id.Val;
            storage.Add(n);
            storageIndex.Add(i);
            storage.Sort();
        }
        /// <summary>
        /// 获取所有节点id
        /// </summary>
        public static int[] GetIDs()
        {
            string ids = "";
            for (int i = 0; i < storageIndex.Count; i++)
            {
                ids = ids + storageIndex[i].ToString() + "|";
            }
            ids = ids.Substring(0, ids.Length - 1);
            string[] idss = ids.Split('|').ToArray();
            var idsss = Array.ConvertAll(idss,s=>int.TryParse(s,out int i) ? i : 0);
            return idsss;
        }
        /// <summary>
        /// 删除单个节点对象
        /// </summary>
        /// <param name="n">单个节点对象</param>
        public static void Del(Node n)
        {
            if (Node.id.Val == null)
            {
                return;
            }
            int i = Node.id.Val;
            int k = storageIndex.IndexOf(i);
            storage.RemoveAt(k);
        }
        /// <summary>
        /// 更新单个节点对象
        /// </summary>
        /// <param name="n">单个节点对象</param>
        public static void Update(Node n)
        {
            if (Node.id.Val == null)
            {
                return;
            }
            int i = Node.id.Val;
            int k = storageIndex.IndexOf(i);
            storage[k] = n;
        }
        private static ArrayList storage = new ArrayList();
        private static ArrayList storageIndex = new ArrayList();
    }
    // 《C#从入门到放弃》
    // 写以上代码的初衷是把从网络发来的节点数据在本地用结构化的方式存储起来，
    // 且单次运行后就销毁，不需要持久化保存，我想到的最好的实现方法就是用类来实现
    // 可是......
    // （实现以下功能大约需要1个月）
    // 使用重载函数进行查询具有局限性，如查询条件不能自由组合，查询键受已定义好的类的约束等
    // 要想实现类似于SQL查询的功能，需要用一个相同的键值对对象作为重载构造函数的每个参数
    // 这样只需要写5个重载构造函数即可，且能实现查询条件的任意组合
    // 然后在重载构造函数内部遍历参数，获取存在键值对对象中的每个键值对
    // 获取到键值对中的键后，使用反射动态构造类，作为查询条件输入负责增删改查的函数如Update
    // 接着在增删改查函数的内部，按重要性依次定义主键
    // 最后将查询结果封装成一个新对象（可能需要用到反射），返回结果
    // 如需网络传输和对接接口，还需在json和类之间进行序列化和反序列化，以便进行数据交换
    // C#是个无底洞，老子不写了。
}
