﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace OGFrp.Lite
{
    public class Net
    {
        public string Get(string Url)
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

        public void Download(string source, string localPath, bool forceDownload = false)
        {
            if (forceDownload)
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
            }else if (!File.Exists(localPath))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
            }
            else
            {
                return;
            }
            return;
        }
    }
}
