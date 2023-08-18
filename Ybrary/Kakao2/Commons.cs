using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
                Console.WriteLine($"사용자 토큰 얻기 성공 {userToken}");
                Ybrary.Kakao2.UserModel.UserToken = userToken;
                return true;
            }
            else
            {
                Console.WriteLine("사용자 토큰 얻기 실패");
                return false;
            }
        }

        /// <summary>
        /// 친구 메시지 토큰 얻기
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <returns></returns>
        public bool GetFriendsToken(WebBrowser webBrowser)
        {
            string url = webBrowser.Url.ToString();
            string friendsToken = url.Substring(url.IndexOf("=") + 1);

            if(url.CompareTo(Ybrary.Kakao2.Values.RedirectUrl +"?code="+friendsToken) == 0)
            {
                Console.WriteLine($"친구 토큰 얻기 성공 {friendsToken}");
                Ybrary.Kakao2.UserModel.FriendsToken = friendsToken;
                return true;
            }
            else
            {
                Console.WriteLine("친구 토큰 얻기 실패");
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

        public void SetFrinedsAccessToken()
        {
            var client = new RestClient(Kakao2.Values.KauthUrl);

            var request = new RestRequest(Kakao2.Values.AccessTokenCommand, Method.POST);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", Kakao2.Values.RestAPIKey);
            request.AddParameter("redirect_uri", Kakao2.Values.RedirectUrl);
            request.AddParameter("code", Ybrary.Kakao2.UserModel.FriendsToken);

            IRestResponse restResponse = client.Execute(request);
            var json = JObject.Parse(restResponse.Content);

            // 토큰 폴더 생성
            folderpath = String.Format(@"{0}{1}", BaseDirectory, "token");
            DirectoryInfo di = new DirectoryInfo(folderpath);
            if (!di.Exists)
            {
                di.Create();
            }
            filepath = String.Format(@"{0}\\Friendstoken.txt", folderpath);
            if (!File.Exists(filepath))
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
        /// 생성된 친구 엑세스 토큰 파일에서 엑세스 토큰 얻기
        /// </summary>
        public void GetFriendsAccessToken()
        {
            if (File.Exists(filepath))
            {
                Console.WriteLine($"친구 토큰 파일 경로 {filepath}");

                using (StreamReader sr = File.OpenText(filepath))
                {
                    string contents = sr.ReadToEnd();
                    JObject acctoken = JObject.Parse(contents);

                    Console.WriteLine((string)acctoken["access_token"].ToString());
                    UserModel.FriendsAccessToken = (string)acctoken["access_token"].ToString();
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

        /// <summary>
        /// 템플릿 메시지 보내기
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool TemplateMessageSend(string message)
        {
            var client = new RestClient(Values.KapiUrl);

            var request = new RestRequest(Values.TemplateMessageUrlCommand, Method.POST);
            request.AddHeader("Authorization", "bearer " + Ybrary.Kakao2.UserModel.AccessToken);
            request.AddParameter("template_id", Ybrary.Kakao2.Values.TemplateID);

            if (client.Execute(request).IsSuccessful)
            {
                Console.WriteLine("메시지 보내기 성공");
                return true;
            }
            else
            {
                Console.WriteLine("메시지 보내기 실패");
                return false;
            }
        }

        /// <summary>
        /// 커스텀 메시지 보내기
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool CustomeMessageSend(string message)
        {
            var client = new RestClient(Values.KapiUrl);

            var request = new RestRequest(Values.DefaultMessageUrlCommand, Method.POST);
            request.AddHeader("Authorization", "bearer " + UserModel.AccessToken);

            JObject JobjSet = new JObject();

            JObject JobjLink = new JObject();
            JobjLink.Add("web_url", "https://www.s-tec.co.kr");
            JobjLink.Add("mobile_web_url", "https://www.s-tec.co.kr");

            JobjSet.Add("object_type", "text");
            JobjSet.Add("text", "[설정할 알림의 타이틀]");
            JobjSet.Add("link", JobjLink);
            JobjSet.Add("button_title", message);

            request.AddParameter("template_object", JobjSet);

            if (client.Execute(request).IsSuccessful)
            {
                Console.WriteLine("메시지 보내기 성공");
                return true;
            }
            else
            {
                Console.WriteLine("메시지 보내기 실패");
                return false;
            }
        }

        /// <summary>
        /// 친구목록 가져오기
        /// </summary>
        public List<FriendsModel> GetFriendsList()
        {
            var client = new RestClient(Values.KapiUrl);

            var request = new RestRequest(Values.FriendsListCommand);

            request.AddHeader("Authorization", "bearer " + UserModel.FriendsAccessToken);

            IRestResponse restResponse = client.Execute(request);
            var json = JObject.Parse(restResponse.Content);
            Console.WriteLine(json.ToString());

            List<FriendsModel> friendsList = new List<FriendsModel>();

            for(int i = 0; i < json["elements"].Count(); i++)
            {
                /*
                if (json["elements"][i]["profile_thumbnail_image"] != null)
                {
                    image = WebImageView(json["elements"][i]["profile_thumbnail_image"].ToString());
                }
                */
                friendsList.Add(new FriendsModel()
                {
                    UserName = json["elements"][i]["profile_nickname"].ToString(),
                    UserId = json["elements"][i]["id"].ToString(),
                    UUID = json["elements"][i]["uuid"].ToString()
                });
            }

            foreach(var item in friendsList)
            {
                Console.WriteLine($"이름 : {item.UserName}");
                Console.WriteLine($"ID : {item.UserId}");
                Console.WriteLine($"UUID : {item.UUID}");
            }

            return friendsList;
        }
        
        /// <summary>
        /// 친구에게 메시지 보내기
        /// </summary>
        /// <param name="message"></param>
        public bool SendFriendsMessage(string targetuuid,string message)
        {
            
            var client = new RestClient(Values.KapiUrl);

            var request = new RestRequest(Values.FriendsMessageUrlCommand,Method.POST);
            request.AddHeader("Authorization", "Bearer " + UserModel.FriendsAccessToken);
            
            string s = $"[\"{targetuuid}\"]";
            request.AddParameter("receiver_uuids", $"{s}");

            JObject JobjSet = new JObject();

            JObject JobjLink = new JObject();
            JobjLink.Add("web_url", "https://www.s-tec.co.kr");
            //JobjLink.Add("web_url", "https://www.naver.co.kr");
            

            JobjSet.Add("object_type", "text");
            JobjSet.Add("text", message);
            JobjSet.Add("link", JobjLink);
            JobjSet.Add("button_title", "확인하기");
            request.AddParameter("template_object", JobjSet);
            

            if (client.Execute(request).IsSuccessful)
            {
                Console.WriteLine("메세지 보내기 성공");
                return true;
            }
            else
            {
                Console.WriteLine("실패");
                return false;
            }
        }


        /*
         [참고사이트]
         https://sosopro.tistory.com/210 SENS SMS 문자보내기
         https://sens.apigw.ntruss.com/apigw/swagger-ui?productId=plv61henn8&apiId=v5ct56inz5&stageId=34jilvhp11&region=KR#/v2/post_services__serviceId__messages SENS Swagger UI
         https://api.ncloud-docs.com/docs/ko/ai-application-service-sens-alimtalkv2 SENS 알람톡 래퍼런스

         [원본데이터]
         {
            "templateCode": "15770722",
            "plusFriendId": "@stecsystem",
            "messages": [
            {
                "countryCode": "82",
                "to": "01091189308",
                "content": "테스트(test) 이름 님의 메시지 테스트내용입니다",
                "buttons":[
                        {
                            "type":"WL",
                            "name":"URL링크",
                            "linkMobile":"https://www.s-tec.co.kr",
                            "linkPc":"https://www.s-tec.co.kr"
                        }
                    ]
            }
            ]
        }
        */
        /// <summary>
        /// 채널 알림톡 보내기
        /// </summary>
        /// <param name="phonenumber"></param>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public void SendChannelMessage(string phonenumber, string name, string content)
        {
            string time = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

            string space = " ";
            string newLine = "\n";
            string method = "POST";
            string url = Values.SearchChannelCommand;

            string message = new StringBuilder()
                .Append(method)
                .Append(space)
                .Append(url)
                .Append(newLine)
                .Append(time)
                .Append(newLine)
                .Append(Values.Channel_AccessKey)
                .ToString();

            string encodeBase64String = String.Empty;
            byte[] secretKey = Encoding.UTF8.GetBytes(Values.Channel_SecreatKey);
            using (HMACSHA256 hmac = new HMACSHA256(secretKey))
            {
                hmac.Initialize();
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                byte[] rawHmac = hmac.ComputeHash(bytes);
                encodeBase64String = Convert.ToBase64String(rawHmac); // 시그니처 키 발급완료
            }

            Console.WriteLine($"생성한 시그니처 키 : {encodeBase64String}");

            //////////////////////////////////////////////////////////////////////////
            string strurl = Values.Channel_MessageURL;

            var request = (HttpWebRequest)WebRequest.Create(strurl);
       
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("x-ncp-apigw-timestamp", time);
            request.Headers.Add("x-ncp-iam-access-key", Values.Channel_AccessKey);
            request.Headers.Add("x-ncp-apigw-signature-v2", encodeBase64String);


            JObject btnobj = new JObject();
            btnobj.Add("type", "WL");
            btnobj.Add("name", "URL링크");
            btnobj.Add("linkMobile", "https://www.s-tec.co.kr");
            btnobj.Add("linkPc", "https://www.s-tec.co.kr");

            JArray arr = new JArray();
            arr.Add(btnobj);

            JObject messageobj = new JObject();
            messageobj.Add("countryCode", "82");
            messageobj.Add("to", $"{phonenumber}");
            messageobj.Add("content", $"테스트(test) {name} 님의 메시지 {content}");
            messageobj.Add("buttons", arr);

            arr = new JArray();
            arr.Add(messageobj);


            JObject result = new JObject();
            result.Add("templateCode", "15770722");
            result.Add("plusFriendId", "@stecsystem");
            result.Add("messages", arr);

            string PostData = result.ToString();

            var data = Encoding.UTF8.GetBytes(PostData);

             using (var stream = request.GetRequestStream())
             {
                 stream.Write(data, 0, data.Length);
             }

             string responseText = string.Empty;
             using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
             {
                 HttpStatusCode status = resp.StatusCode;
                 Console.WriteLine(status);

                 Stream restStream = resp.GetResponseStream();
                 using(StreamReader sr = new StreamReader(restStream))
                 {
                     responseText = sr.ReadToEnd();
                 }
             }

         Console.WriteLine(responseText);
        }
    }
}
