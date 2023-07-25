using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Ybrary.Kakao.Models;

namespace Ybrary.Kakao
{
    public class Commons
    {
        public Commons()
        {
                
        }
    
        /// <summary>
        /// 사용자 토큰 얻기
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <returns></returns>
        public bool GetUserToken(WebBrowser webBrowser)
        {
            string wUrl = webBrowser.Url.ToString();
            string userToken = wUrl.Substring(wUrl.IndexOf("=") + 1);

            if(wUrl.CompareTo(Ybrary.Kakao.Values.RedirectUrl + "?code=" + userToken) == 0)
            {
#if DEBUG
                Console.WriteLine($"유저 토큰 얻기 <성공> : {userToken}");
#endif
                UserModel.UserToken = userToken;
                Console.WriteLine($"유저토큰 {UserModel.UserToken}");
                return true;
            }
            else
            {
                Console.WriteLine($"유저 토큰 얻기 <실패> : {userToken}");
                return false;
            }
        }

        /// <summary>
        /// 사용자 토큰 접근
        /// </summary>
        /// <returns></returns>
        public bool GetAccessToken()
        {
            var client = new RestClient(Values.HostOauthUrl);
            
            // REST 요청 정보
            var request = new RestRequest("/oauth/token", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", Values.RestApiKey);
            request.AddParameter("redirect_uri", Values.RedirectUrl);
            request.AddParameter("code", UserModel.UserToken);

            IRestResponse restResponse = client.Execute(request);
            var json = JObject.Parse(restResponse.Content);

            if(json != null)
            { 
                UserModel.AccessToken = json["access_token"].ToString();
                Console.WriteLine($"엑세스 토큰 : {json["access_token"].ToString()}");
                Console.WriteLine($"엑세스 토큰 : {UserModel.AccessToken}");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 로그아웃 기능
        /// </summary>
        public bool LogOut()
        {
            var client = new RestClient(Values.HostApiUrl);
            var request = new RestRequest(Values.UnlinkUrlCommand, Method.POST);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);

            if (client.Execute(request).IsSuccessful)
            {
#if DEBUG
                Console.WriteLine($"로그아웃 <성공> {UserModel.AccessToken}");
#endif
                return true;
            }
            else
            {
#if DEBUG
                Console.WriteLine($"로그아웃 <실패> {UserModel.AccessToken}");
#endif
                return false;
            }
        }

        /// <summary>
        /// 유저 데이터 받아오기
        /// </summary>
        public void GetUserData()
        {
            var client = new RestClient(Values.HostApiUrl);

            var request = new RestRequest(Values.UserDataUrlCommand, Method.GET);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);

            var restResponse = client.Execute(request);

            var json = JObject.Parse(restResponse.Content);

            // 프로필 사진이 없을 경우 예외 처리
            if (json["properties"]["profile_image"] != null)
            {
                string UserImgUrl = json["properties"]["profile_image"].ToString();
                UserModel.UserImg = WebImageView(UserImgUrl);
            }

            UserModel.UserNickName = json["properties"]["nickname"].ToString();
        }

        /// <summary>
        /// 프로필 이미지 Bitmap 저장
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static Bitmap WebImageView(string url)
        {
            try
            {
                using(WebClient Downloader = new WebClient())
                using (Stream ImageStream = Downloader.OpenRead(url))
                {
                    Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;
#if DEBUG
                    Console.WriteLine("이미지 다운 성공");
#endif
                    return DownloadImage;
                }
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine("이미지 다운 실패");
#endif
                return null;
            }
        }


        /// <summary>
        /// 템플릿 메시지 보내기
        /// </summary>
        /// <param name="key"></param>
        public bool TemplateMeesageSend(string key)
        {
            var client = new RestClient(Values.HostApiUrl);

            var request = new RestRequest(Values.TemplateMessageUrlCommand, Method.POST);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);
            request.AddParameter("template_id", key);

            if (client.Execute(request).IsSuccessful)
            {
#if DEBUG
                Console.WriteLine("메시지 보내기 성공");
#endif
                return true;
            }
            else
            {
#if DEBUG
                Console.WriteLine("메시지 보내기 실패");
#endif
                return false;
            }
        }

        /// <summary>
        /// 커스텀 메시지 보내기
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool CustomMessageSend(JObject message)
        {
            var client = new RestClient(Values.HostApiUrl);

            var request = new RestRequest(Values.DefaultMessageUrlCommand, Method.POST);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);
            request.AddParameter("template_object", message);

            if (client.Execute(request).IsSuccessful)
            {
#if DEBUG
                Console.WriteLine("메시지 보내기 성공");
#endif
                return true;
            }
            else
            {
#if DEBUG
                Console.WriteLine("메시지 보내기 성공");
#endif
                return false;
            }
        }

        /// <summary>
        /// 친구 데이터 가져오기
        /// </summary>
        public void GetFriendsData()
        {
            var client = new RestClient(Values.HostApiUrl);
            
            var request = new RestRequest("v1/api/talk/friends");
            
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);

            IRestResponse restResponse = client.Execute(request);
            Console.WriteLine(restResponse.Content);
        }


        


    }
}
