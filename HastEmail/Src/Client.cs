using System;
using System.Diagnostics;

namespace HastEmail.Src
{
    public class Client
    {
        public User user;

        public Client(string _User, string _Passwd)
        {
            user = new User(_User, _Passwd);
        }

        public static bool IsEmailValid(string email)
        {
            try
            {
                System.Net.Mail.MailAddress eMailValidator = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione nella gestione della mail, forse non è nel formato corretto? \n {ex}");
                return false;
            }
        }
    }
}