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
using KonwerterWiadomosci.ViewModel;
using Twilio;
namespace KonwerterWiadomosci
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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextMessage.Text = string.Empty;
           
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string txt = TextMessage.Text;
           // string nadawca = WhoSend.Text;
            string number = PhoneNumber.Text;

            //APISMS.SendSms(message, nadawca, number);
            Twiloo.TwilooSms(txt, number);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            TextMessage.Text = " Zapraszam jutro do pracy na 13";
            PhoneNumber.Text = "03941";
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            TextMessage.Text = " Jutro wolne.";
            PhoneNumber.Text = "2311211";
             
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            TextMessage.Text = "Proszę wejść tylnym wyjściem.";
            PhoneNumber.Text = " 799";
            
        }
    }
}
