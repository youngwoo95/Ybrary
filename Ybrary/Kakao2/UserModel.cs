using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ybrary.Kakao2
{
    public class UserModel
    {
        /// <summary>
        /// 사용자 토큰
        /// </summary>
        public static string UserToken { get; set; }

        /// <summary>
        /// 엑세스 토큰
        /// </summary>
        public static string AccessToken { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        public static string UserName { get; set; }

        /// <summary>
        /// 사용자 프로필 이미지
        /// </summary>
        public static Bitmap UserProfileImg { get; set; }
    }
}
