using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ybrary.Kakao.Models
{
    /// <summary>
    /// 사용자 모델클래스
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 유저 토큰
        /// </summary>
        public static string UserToken { get; set; }

        /// <summary>
        /// 엑세스 토큰
        /// </summary>
        public static string AccessToken { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        public static string UserNickName { get; set; }
        
        /// <summary>
        /// 사용자 이미지
        /// </summary>
        public static Bitmap UserImg { get; set; }


    }
}
