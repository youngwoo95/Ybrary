using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KakaoTest
{
    public partial class KakaoLoginPage : Form
    {
        Ybrary.Kakao.Commons kakaoManager;

        public KakaoLoginPage()
        {
            InitializeComponent();
        }

        private void KakaoLoginPage_Load(object sender, EventArgs e)
        {
            kakaoManager = new Ybrary.Kakao.Commons();

            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted; // 웹 브라우저 창이 로드 될 때 마다 발생하는 이벤트 등록
            webBrowser1.ScriptErrorsSuppressed = true; // 스크립트 접근 에러 표시 안함
            webBrowser1.Navigate(Ybrary.Kakao.Values.LogInUrl); // 로그인 URL 연결
        }

        /// <summary>
        /// 이벤트 핸들러 정의
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (kakaoManager.GetUserToken(webBrowser1))
            {
                kakaoManager.GetAccessToken();
                this.Close();
            }
        }

    }
}
