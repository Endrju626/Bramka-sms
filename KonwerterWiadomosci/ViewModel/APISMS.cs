﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SMSApi.Api;


namespace KonwerterWiadomosci.ViewModel
{
    internal class APISMS
    {
        

        internal static void SendSms(string message, string number,string nadawca)
        {
            try
            {   
                SMSApi.Api.IClient client = new SMSApi.Api.ClientOAuth("xAMzMzNCeqWZW2dmLrSylKnAnj0JaTJeTk19nQWu");

                var smsApi = new SMSApi.Api.SMSFactory(client);
                // for SMSAPI.com clients:
                // var smsApi = new SMSApi.Api.SMSFactory(client, ProxyAddress.SmsApiCom);

                var result =
                    smsApi.ActionSend()
                        .SetText(message)
                        .SetTo("+48501368694")  //"+48501368694"
                        .SetSender("test") //"test"
                        .Execute();

                System.Console.WriteLine("Send: " + result.Count);

                string[] ids = new string[result.Count];

                for (int i = 0, l = 0; i < result.List.Count; i++)
                {
                    if (!result.List[i].isError())
                    {
                        if (!result.List[i].isFinal())
                        {
                            ids[l] = result.List[i].ID;
                            l++;
                        }
                    }
                }

                System.Console.WriteLine("Get:");
                result =
                    smsApi.ActionGet()
                        .Ids(ids)
                        .Execute();

                foreach (var status in result.List)
                {
                    System.Console.WriteLine("ID: " + status.ID + " Number: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
                }
                MessageBox.Show("Wiadomość SMS została wysłana pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SMSApi.Api.ActionException e)
            {
                /**
                 * Action error
                 */
                System.Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SMSApi.Api.ClientException e)
            {
                /**
                 * Error codes (list available in smsapi docs). Example:
                 * 101 	Invalid authorization info
                 * 102 	Invalid username or password
                 * 103 	Insufficient credits on Your account
                 * 104 	No such template
                 * 105 	Wrong IP address (for IP filter turned on)
                 * 110	Action not allowed for your account
                 */
                System.Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SMSApi.Api.HostException e)
            {
                /* 
                 * Server errors
                 * SMSApi.Api.HostException.E_JSON_DECODE - problem with parsing data
                 */
                System.Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SMSApi.Api.ProxyException e)
            {
                // communication problem between client and sever
                System.Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
