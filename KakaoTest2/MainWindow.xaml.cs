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

namespace KakaoTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Ybrary.Kakao2.Commons Comm;

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
            txtName.Text = Ybrary.Kakao2.UserModel.UserName;
            
        }

     
    }
}
