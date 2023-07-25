using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ybrary.Kakao;

namespace KakaoTest
{
    public partial class Form1 : Form
    {
        private Ybrary.Kakao.Commons kakaoManager;
        KakaoLoginPage login;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kakaoManager = new Ybrary.Kakao.Commons();
            //WebBrowserVersionSetting();
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            login = new KakaoLoginPage();
            login.ShowDialog();
        }

        /// <summary>
        /// 사용자 데이터 불러오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UserData_Click(object sender, EventArgs e)
        {
            kakaoManager.GetUserData();

            pbBox.Image = Ybrary.Kakao.Models.UserModel.UserImg;
            lblUserName.Text = Ybrary.Kakao.Models.UserModel.UserNickName;

        }
        
        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            kakaoManager.LogOut();
        }

        /// <summary>
        /// 템플릿 메시지 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TemplateMessage_Click(object sender, EventArgs e)
        {
            kakaoManager.TemplateMeesageSend(Values.MessageTemplateKey);
        }

        /// <summary>
        /// 커스텀 메시지 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CustomMessage_Click(object sender, EventArgs e)
        {
            JObject SendJson = new JObject();
            JObject LinkJson = new JObject();

            LinkJson.Add("web_url", "https://developers.kakao.com");
            LinkJson.Add("mobile_web_url", "https://developers.kakao.com");

            SendJson.Add("object_type", "text");
            SendJson.Add("text","커스텀메시지타이틀내용");
            SendJson.Add("link", LinkJson);
            SendJson.Add("button_title", "버튼내용");


            kakaoManager.CustomMessageSend(SendJson);
        }





        /// <summary>
        /// 브라우저 버전 세팅
        /// </summary>
        private void WebBrowserVersionSetting()
        {
            RegistryKey registryKey = null; // 레지스트리 변경에 사용 될 변수

            int browserver = 0;
            int ie_emulation = 0;
            var targetApplication = Process.GetCurrentProcess().ProcessName + ".exe"; // 현재 프로그램 이름

            // 사용자 IE 버전 확인
            using (WebBrowser wb = new WebBrowser())
            {
                browserver = wb.Version.Major;
                if (browserver >= 11)
                    ie_emulation = 11001;
                else if (browserver == 10)
                    ie_emulation = 10001;
                else if (browserver == 9)
                    ie_emulation = 9999;
                else if (browserver == 8)
                    ie_emulation = 8888;
                else
                    ie_emulation = 7000;
            }

            try
            {
                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);

                // IE가 없으면 실행 불가능
                if (registryKey == null)
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return;
                }

                string FindAppkey = Convert.ToString(registryKey.GetValue(targetApplication));

                // 이미 키가 있다면 종료
                if (FindAppkey == ie_emulation.ToString())
                {
                    registryKey.Close();
                    return;
                }

                // 키가 없으므로 키 셋팅
                registryKey.SetValue(targetApplication, unchecked((int)ie_emulation), RegistryValueKind.DWord);

                // 다시 키를 받아와서
                FindAppkey = Convert.ToString(registryKey.GetValue(targetApplication));

                // 현재 브라우저 버전이랑 동일 한지 판단
                if (FindAppkey == ie_emulation.ToString())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                Application.Exit();
                return;
            }
            finally
            {
                // 키 메모리 해제
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }

        /// <summary>
        /// 친구 데이터 가져오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendsData_Click(object sender, EventArgs e)
        {
            kakaoManager.GetFriendsData();
        }
    }
}
