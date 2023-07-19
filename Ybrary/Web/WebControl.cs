﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace Ybrary.Web
{
    public class WebControl
    {
        public static void RequestURL()
        {
            string url = "http://localhost:1180";

            Uri uri = new Uri(url);
            HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "GET";

            using (HttpWebResponse wRes = (HttpWebResponse)wReq.GetResponse())
            {
                Stream respPostStream = wRes.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                //Console.WriteLine(readerPost.ReadToEnd());
                Console.WriteLine(readerPost.ReadLine());
            }

        }

    }
}
