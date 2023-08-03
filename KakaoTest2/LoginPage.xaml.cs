using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KakaoTest2
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPage : Window
    {
        public int type { get; set; }

        public string tokenType { get; set; }
        
        System.Windows.Forms.WebBrowser wb;

        public LoginPage()
        {
            InitializeComponent();
        }
        
        // 토큰타입

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            MainWindow.Comm = new Ybrary.Kakao2.Commons();

            wb = new System.Windows.Forms.WebBrowser();
            webBrowser1.Child = wb;
            wb.DocumentCompleted += DocumentCompleted;
            wb.ScriptErrorsSuppressed = true; // 스크립트 에러 제거

            // 이 아래부분 ShowDialog 하면서 넘겨야할듯
            wb.Navigate(tokenType); // 사용자 코드 URL 설정
        }

        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (type)
            {
                case 1:
                    if (MainWindow.Comm.GetUserToken(wb))
                    {
                        MainWindow.Comm.SetAccessToken();
                        this.Close();
                    }
                    break;
                case 2:
                    if (MainWindow.Comm.GetFriendsToken(wb))
                    {
                        MainWindow.Comm.SetFrinedsAccessToken();
                        this.Close();
                    }
                    break;
            }

            
        }
    }
}
