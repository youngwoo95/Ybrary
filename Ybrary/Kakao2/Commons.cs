﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Ybrary.Networks.MQTT;

namespace Ybrary.Kakao2
{
    public class Commons
    {
        // 베이스 디렉토리 경로
        private string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Commons()
        {
                
        }

        public bool GetUserToken(WebBrowser webBrowser)
        {
            string url = webBrowser.Url.ToString();
            string userToken = url.Substring(url.IndexOf("=") + 1);

            // 웹브라우저 상 URL 과 지정한 토큰 URL이 같을경우
            if(url.CompareTo(Ybrary.Kakao2.Values.RedirectUrl +"?code="+userToken) == 0)
            {
                Console.WriteLine($"유저 토큰 얻기 성공 {userToken}");
                Ybrary.Kakao2.UserModel.UserToken = userToken;
                return true;
            }
            else
            {
                Console.WriteLine("유저 토큰 얻기 실패");
                return false;
            }

        }
        string folderpath;
        string filepath;
        /// <summary>
        /// 엑세스 토큰 파일 생성
        /// </summary>
        public void SetAccessToken()
        {
            var client = new RestClient(Kakao2.Values.KauthUrl);

            // REST 요청 정보
            var request = new RestRequest(Kakao2.Values.AccessTokenCommand, Method.POST);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", Kakao2.Values.RestAPIKey);
            request.AddParameter("redirect_uri", Kakao2.Values.RedirectUrl);
            request.AddParameter("code", Ybrary.Kakao2.UserModel.UserToken);

            IRestResponse restResponse = client.Execute(request);
            var json = JObject.Parse(restResponse.Content);

            // 토큰 폴더 생성
            folderpath = String.Format(@"{0}{1}", BaseDirectory, "token");
            DirectoryInfo di = new DirectoryInfo(folderpath);
            if (!di.Exists)
            {
                di.Create();
            }

            filepath = String.Format(@"{0}\\token.txt", folderpath);
            if(!File.Exists(filepath))
            {
                using (File.Create(filepath)) { }
            }

            File.WriteAllText(filepath, json.ToString());
        }

        /// <summary>
        /// 생성된 엑세스 토큰 파일에서 엑세스토큰 얻기
        /// </summary>
        public void GetAccessToken()
        {
            if (File.Exists(filepath))
            {
                Console.WriteLine($"토큰 파일 경로 {filepath}");

                using (StreamReader sr = File.OpenText(filepath))
                {
                    string contents = sr.ReadToEnd();
                    JObject acctoken = JObject.Parse(contents);

                    Console.WriteLine((string)acctoken["access_token"].ToString());
                    UserModel.AccessToken = (string)acctoken["access_token"].ToString();

                }
            }
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <returns></returns>
        public bool LotOut()
        {
            var client = new RestClient(Ybrary.Kakao2.Values.KapiUrl);

            var request = new RestRequest(Ybrary.Kakao2.Values.UnlinkTokenCommand, Method.POST);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);

            if (client.Execute(request).IsSuccessful)
            {
                Console.WriteLine($"로그아웃 성공 {UserModel.AccessToken}");
                return true;
            }
            else
            {
                Console.WriteLine("로그아웃 실패");
                return false;
            }
        }

        /// <summary>
        /// 사용자 정보 얻기
        /// </summary>
        public void GetUserData()
        {
            var client = new RestClient(Ybrary.Kakao2.Values.KapiUrl);

            var request = new RestRequest(Ybrary.Kakao2.Values.GetUserDataTokenCommand, Method.GET);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);

            var response = client.Execute(request);
            var json = JObject.Parse(response.Content);

            if (json["properties"]["profile_image"] != null)
            {
                string UserImg = json["properties"]["profile_image"].ToString();
                UserModel.UserProfileImg = WebImageView(UserImg);
            }

            UserModel.UserName = json["properties"]["nickname"].ToString();
        }

        private static Bitmap WebImageView(string url)
        {
            try
            {
                using(WebClient Downloader = new WebClient())
                using (Stream ImageStream = Downloader.OpenRead(url))
                {
                    Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;

                    Console.WriteLine("이미지 다운로드 성공");
                    return DownloadImage;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}
