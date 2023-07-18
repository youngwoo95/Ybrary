using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Ybrary.Web
{
    public class WebControl
    {
        /// <summary>
        /// REQUEST : 요청
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RequestURL(string url)
        {
            // 설정
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";

            // 응답
            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse()) // 요청
            {
                Stream respStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respStream, Encoding.GetEncoding("UTF-8"), true);

                return reader.ReadToEnd(); // 요청 결과 반환
            }
        }




    }
}
