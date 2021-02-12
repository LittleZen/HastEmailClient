using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HastEmail.Src
{
    public class User : BlackList
    {
        public User(string _Username, string _Password)
        {
            username = _Username;
            password = _Password;
        }

        public User()
        {
            username = null;
            password = null;
        }

        ~User()
        {
            // None
        }

        public string username;

        public string password;

        public string Username
        {
            get => default;
            set
            {
                if (!string.IsNullOrEmpty(username))
                    username = value;
            }
        }

        public string Password
        {
            get => default;
            set
            {
                if (!string.IsNullOrEmpty(password))
                    password = value;
            }
        }

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

        public string LoginJson()
        {
            try
            {
                return Server.MakeRequest(this, "POST", Server.LoginURL);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione: {ex}");
                return null;
            }
        }
    }
}