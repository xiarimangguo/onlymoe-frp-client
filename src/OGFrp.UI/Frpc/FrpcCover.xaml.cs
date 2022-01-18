﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace OGFrp.UI
{
    /// <summary>
    /// FrpcCover.xaml 的交互逻辑
    /// </summary>
    public partial class FrpcCover : UserControl
    {
        public FrpcCover()
        {
            InitializeComponent();
        }

        public string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        /// <summary>
        /// 对应的frpc
        /// </summary>
        private Frpc frpc = new Frpc();

        /// <summary>
        /// 用于展示的服务器地址
        /// </summary>
        public string ServerAddr;

        /// <summary>
        /// 用于展示的隧道名称
        /// </summary>
        public string ProxyName;

        /// <summary>
        /// 用于启动frpc时使用的frpc.ini
        /// </summary>
        public string iniFile;

        /// <summary>
        /// frpc.exe路径
        /// </summary>
        public string frpcLoca;

        /// <summary>
        /// 文本前景色
        /// </summary>
        private Brush TextForeColor = Brushes.White;

        /// <summary>
        /// 设置用于展示的隧道名称
        /// </summary>
        /// <param name="Name"></param>
        public void SetProxyName(string Name)
        {
            this.lb_ProxyName.Content = Name;
        }

        /// <summary>
        /// 设置用于展示的节点名称
        /// </summary>
        /// <param name="Name"></param>
        public void SetServerName(string Name)
        {
            this.lb_serverName.Content = Name;
        }

        /// <summary>
        /// 设置前景色
        /// </summary>
        /// <param name="Color">要设置的前景色</param>
        public void SetTextForeColor(Brush Color)
        {
            this.lb_ProxyName.Foreground = Color;
            this.lb_serverName.Foreground = Color;
            this.bd_main.BorderBrush = Color;
        }

        /// <summary>
        /// 设置显示日志“超链接”的文字
        /// </summary>
        /// <param name="Content"></param>
        public void SetViewLogContent(string Content)
        {
            this.lb_ViewLog.Content = Content;
        }

        /// <summary>
        /// 设置用于启动frpc的frpc.ini的内容
        /// </summary>
        /// <param name="iniFile"></param>
        public void SetIniFile(string iniFile)
        {
            this.iniFile = iniFile;
        }

        /// <summary>
        /// 设置frpc.exe的位置
        /// </summary>
        /// <param name="frpcLoca"></param>
        public void SetFrpcLoca(string frpcLoca)
        {
            this.frpcLoca = frpcLoca;
        }

        private void startFrpc()
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(appDataPath + "\\ini_his");
                string tIniLoca = appDataPath + "\\ini_his\\ini_" + DateAndTime.DateString + DateAndTime.TimeString.Replace(":", "-") + ".ini";
                Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(tIniLoca, iniFile, false);
                frpc.setFrpcLoca(this.frpcLoca);
                frpc.setIniLoca(tIniLoca);
                int succeed = frpc.Start();
                if (succeed == -1)
                {
                    this.cb_Switch.IsChecked = false;
                    this.lb_ViewLog.Visibility = (bool)this.cb_Switch.IsChecked ? Visibility.Visible : Visibility.Hidden;
                }
            }
            catch
            {
                this.cb_Switch.IsChecked = false;
                this.lb_ViewLog.Visibility = (bool)this.cb_Switch.IsChecked ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void cb_Switch_Click(object sender, RoutedEventArgs e)
        {
            this.lb_ViewLog.Visibility = (bool)this.cb_Switch.IsChecked ? Visibility.Visible : Visibility.Hidden;
            if (cb_Switch.IsChecked == true)
                startFrpc();
            else
                frpc.Kill();
        }
    };
}