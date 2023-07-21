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

        public MainWindow()
        {
            InitializeComponent();
        }

        private string Key = "01235230958230598230512312312398";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string text = "암호화내용";
            Console.WriteLine($"원문 : {text}");
            text = Ybrary.Encry.AES128.Encrypt(text, Key);
            Console.WriteLine($"암호화 된 문자 : {text}");

            text = Ybrary.Encry.AES128.Decrypt(text, Key);
            Console.WriteLine($"복호화 된 문자 : {text}");

            Console.WriteLine($"원문 : {text}");
            text = Ybrary.Encry.AES256.Encrypt(text, Key);
            Console.WriteLine($"암호화 된 문자 : {text}");
            text = Ybrary.Encry.AES256.Decrypt(text, Key);
            Console.WriteLine($"복호화 된 문자 : {text}");
        }

    }
}
