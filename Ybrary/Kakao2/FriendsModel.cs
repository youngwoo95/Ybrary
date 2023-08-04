using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ybrary.Kakao2
{
    public class FriendsModel
    {
        /// <summary>
        /// 친구 이름
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 친구 프로필 이미지
        /// </summary>
        //public Bitmap UserProfileImg { get; set; }

        /// <summary>
        /// 친구 ID
        /// </summary>
        public string UserId { get; set; }
        

        /// <summary>
        /// UUID - 메시지 보낼때 사용됨
        /// </summary>
        public string UUID { get; set; }

        

    }
}
