using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Kakao
{
    public class Values
    {
        /// <summary>
        /// 네이티브 앱 키
        /// </summary>
        public static string NativeAppKey = "4768c122f19bd1583cc4ad625eee696d";

        /// <summary>
        /// REST API 키
        /// </summary>
        public static string RestApiKey = "7b3ff68aec8b85b852ff4180e8bdf141";

        /// <summary>
        /// JavaScript 키
        /// </summary>
        public static string JavaScriptKey = "1e155e1a82169f69b145640e1a1a37ed";

        /// <summary>
        /// Admin 키
        /// </summary>
        public static string AdminKey = "8a4a304661bc48ca4b72b47e0e43dba8";

        /// <summary>
        /// 템플릿 메시지 디자인 Key
        /// </summary>
        public static string MessageTemplateKey = "96406";

        /// <summary>
        /// 리다이렉트 URL
        /// </summary>
        public static string RedirectUrl = "https://www.naver.com/oauth";

        /// <summary>
        /// 친구목록 정보 얻기
        /// </summary>
        //public static string LogInUrl = "https://kauth.kakao.com/oauth/authorize?response_type=code&client_id=" + RestApiKey + "&redirect_uri=" + RedirectUrl + "&response_type=code&scope=talk_message,friends";

        // 사용자 정보얻기
        public static string LogInUrl = "https://kauth.kakao.com/oauth/authorize?response_type=code&client_id=" + RestApiKey + "&redirect_uri=" + RedirectUrl + "&scope=talk_message,friends";

        /// <summary>
        /// 루트 URL
        /// </summary>
        #region 루트 URL
        public static string HostOauthUrl = "https://kauth.kakao.com";
        public static string HostApiUrl = "https://kapi.kakao.com";
        #endregion

        #region 이벤트 URL COMMAND
        /// <summary>
        /// AccessToken 커맨드
        /// </summary>
        public static string AccessTokenCommand = "/oauth/token";

        /// <summary>
        /// 로그아웃 커맨드
        /// </summary>
        public static string UnlinkUrlCommand = "/v1/user/unlink";

        /// <summary>
        /// 템플릿 메시지 커맨드
        /// </summary>
        public static string TemplateMessageUrlCommand = "/v2/api/talk/memo/send";

        /// <summary>
        /// 기본 메시지 커맨드
        /// </summary>
        public static string DefaultMessageUrlCommand = "v2/api/talk/memo/default/send";

        /// <summary>
        /// 사용자 데이터 커맨드
        /// </summary>
        public static string UserDataUrlCommand = "/v2/user/me";
        //public static string UserDataUrlCommand = "/v1/api/talk/profile";
        /// <summary>
        /// 친구 데이터 커맨드
        /// </summary>
        //public static string FriendsDataUrlCommand = "v1/api/talk/frineds";
        public static string FriendsDataUrlCommand = "v1/api/talk/friends";
        #endregion


    }
}
