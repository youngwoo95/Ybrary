using System;
using System.Collections.Generic;
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
using Ybrary.Networks.MQTT;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ybrary.Networks.Sockets.Server server;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            server = new Ybrary.Networks.Sockets.Server();
            server.ReceiveHandler += new Ybrary.Networks.Sockets.delSocketServer(MyHanlder);

            await server.Start(1822);

        }

        public string MyHanlder(string message)
        {
            Console.WriteLine($"호출된 이벤트 내용 : {message}");
            return message;   
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            server.Stop();
           
        }
    }
}
