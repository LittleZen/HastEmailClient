using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace HastEmail.Src
{
    public class User : BlackList
    {
        public User(string _Username, string _Password)
        {
            username = _Username;
            password = _Password;
        }

        public string username;
        public string password;

        public bool Login()
        {
            try
            {
                //This line return always false...
                return JsonConvert.DeserializeObject<ServerResponse>(Server.MakeRequest(this, "POST", Server.LoginURL)).Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione: {ex}");
                return false;
            }
        }
    }
}