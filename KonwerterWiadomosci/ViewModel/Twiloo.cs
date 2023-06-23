using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace KonwerterWiadomosci.ViewModel
{
    internal class Twiloo
    {
        internal static void TwilooSms(string txt, string number)
        {
            TwilioClient.Init("AC67be2dc30f3f4f0eee98d564629c549d", "fde153d2858af7085d0d577284acae6e");

            var message = MessageResource.Create(
                new PhoneNumber(number),
                from: new PhoneNumber("+13159155600"),
                body: txt
            );
            Console.WriteLine(message.Sid);
            MessageBox.Show("Wiadomość SMS została wysłana pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}


    
