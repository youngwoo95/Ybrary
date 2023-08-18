using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ybrary.Kakao.Models;
using Ybrary.Kakao2;

namespace KakaoTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Ybrary.Kakao2.Commons Comm;
        List<FriendsModel> friendslist;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Comm = new Ybrary.Kakao2.Commons();
        }

        /// <summary>
        /// 사용자 토큰 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUserToken_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.type = 1;
            login.tokenType = Ybrary.Kakao2.Values.OauthHost;
            login.ShowDialog();
        }

        /// <summary>
        /// 친구 토큰 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetFriendsToken_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.type = 2;
            login.tokenType = Ybrary.Kakao2.Values.FriendsOauthHost;
            login.ShowDialog();
        }

        /// <summary>
        /// 사용자 토큰 얻기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUserToken_Click(object sender, RoutedEventArgs e)
        {
            Comm.GetAccessToken();
        }

        private void btnGetFriendsToken_Click(object sender, RoutedEventArgs e)
        {
            Comm.GetFriendsAccessToken();
        }


      

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Comm.LotOut();
        }

        /// <summary>
        /// 사용자 프로필 얻기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetProfile_Click(object sender, RoutedEventArgs e)
        {
            Comm.GetUserData();
            // 프로필 사진 구현

            //imgProfile.Source = new Uri(Ybrary.Kakao2.UserModel.UserProfileImg)

            txtName.Text = Ybrary.Kakao2.UserModel.UserName;
            
        }

        /// <summary>
        /// 나에게 커스텀 메시지 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMyTemplateMessage_Click(object sender, RoutedEventArgs e)
        {
            Comm.TemplateMessageSend(txtMessage.Text);
        }

        /// <summary>
        /// 나에게 기본 메시지 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMyDefaultMessage_Click(object sender, RoutedEventArgs e)
        {
            Comm.CustomeMessageSend(txtMessage.Text);
            txtMessage.Clear();
        }

        /// <summary>
        /// 친구목록 가져오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetFriendsList_Click(object sender, RoutedEventArgs e)
        {
            friendslist = Comm.GetFriendsList();
        }

        /// <summary>
        /// 친구에게 메시지 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFriendsMessage_Click(object sender, RoutedEventArgs e)
        {
            Comm.SendFriendsMessage(friendslist[1].UUID, txtFriendsMessage.Text);
            txtFriendsMessage.Clear();
        }

        private void btnGetChannel_Click(object sender, RoutedEventArgs e)
        {
            Comm.SendChannelMessage("01091189308","김용우","테스트데이터");
        }
    }
}
