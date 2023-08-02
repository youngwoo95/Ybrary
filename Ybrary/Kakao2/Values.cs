using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Kakao2
{
    public class Values
    {
        /// <summary>
        /// 네이티브 앱 키
        /// </summary>
        public static string NativeKey = "78cb71b941cde490ef93df710cc9ad13";

        /// <summary>
        /// REST API 키
        /// </summary>
        public static string RestAPIKey = "45583ff9698379097419eaa0ddb0019b";

        /// <summary>
        /// JavaScript 키
        /// </summary>
        public static string JavaScriptKey = "3a7a46d89ddba78d4a3dcfe145f2989e";

        /// <summary>
        /// Admin 키
        /// </summary>
        public static string AdminKey = "aad63c9e6b06339e19a00ab5a59f78e9";

        /// <summary>
        /// 앱 ID
        /// </summary>
        public static string AppID = "948737";

        /// <summary>
        /// 메시지 템플릿 ID
        /// </summary>
        public static string TemplateID = "96783";

        /// <summary>
        /// 리다이렉트 URL
        /// </summary>
        public static string RedirectUrl = "https://www.s-tec.co.kr/oauth";

        /// <summary>
        /// 인증코드 요청 Url
        /// </summary>
        public static string OauthHost = $"https://kauth.kakao.com/oauth/authorize?client_id={RestAPIKey}&redirect_uri={RedirectUrl}&response_type=code";

        /// <summary>
        /// 엑세스 인증 URL
        /// </summary>
        public static string KauthUrl = "https://kauth.kakao.com";


        #region COMMAND
        /// <summary>
        /// 엑세스 토큰 명령어
        /// </summary>
        public static string AccessTokenCommand = "/oauth/token";

        #endregion
    }
}
