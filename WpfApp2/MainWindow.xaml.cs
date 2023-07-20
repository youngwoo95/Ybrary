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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void btnClient_Click(object sender, RoutedEventArgs e)
        {
            await Ybrary.Networks.MQTT.Client.ClientStart("127.0.0.1", 1882, "123", "123");
            await Ybrary.Networks.MQTT.Client.SubScribe("123");
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            byte[] s = Ybrary.Networks.MQTT.Client.GetMessage();
            foreach(var item in s)
            {
                Console.WriteLine(item);
            }

            string te = Ybrary.Networks.MQTT.Client.GetConvertMessage();
            Console.WriteLine(te);
        }

        private async void btntest2_Click(object sender, RoutedEventArgs e)
        {
            await Ybrary.Networks.MQTT.Client.SubScribe("456");
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            await Ybrary.Networks.MQTT.Client.Publish("123", "내용입니다");
        }
    }
}
