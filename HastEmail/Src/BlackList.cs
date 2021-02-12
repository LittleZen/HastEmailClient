using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HastEmail.Src
{
    public class BlackList
    {
        public BlackList()
        {
            blackEmails = new List<string>();
        }

        ~BlackList()
        {
            // None
        }

        private List<string> blackEmails;

        public List<string> BlackEmails
        {
            get => blackEmails;
            set
            {
                blackEmails = value;
            }
        }

        public bool AddEmail(User user, string sURL)
        {
            try
            {
                var request = Server.MakeRequest(user, "PATCH", sURL);
                //return JsonConvert.DeserializeObject<ServerResponse>(Server.MakeRequest(user, "PATCH", sURL)).Success;
                return JsonConvert.DeserializeObject<ServerResponse>(request).Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione generica: {ex}");
            }
            return false;
        }

        public bool RemoveEmail(User user, string sURL)
        {
            try
            {
                var request = Server.MakeRequest(user, "DELETE", sURL);
                return JsonConvert.DeserializeObject<ServerResponse>(request).Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione generica: {ex}");
            }
            return false;
        }

        public bool CheckEmail(string sURL)
        {
            try
            {
                var request = Server.MakeRequest(sURL);
                return JsonConvert.DeserializeObject<ServerResponse>(request).Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione generica: {ex}");
            }
            return false;
        }

        public BlackList GetList(User user, string sURL)
        {
            try
            {
                var request = Server.MakeRequest(sURL);
                return JsonConvert.DeserializeObject<BlackList>(request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Eccezione generica: {ex}");
            }
            return null;
        }

        public ListResult GetList()
        {
            try
            {
                // Making "GET" request, using "MakeRequest" overload function
                string serverResponse = Server.MakeRequest(Server.ListURL);

                // Deserialize the response through a class
                ListResult DeserializedObj = JsonConvert.DeserializeObject<ListResult>(serverResponse);

                return DeserializedObj;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex}");
                return null;
            }
        }


        public class ListResult
        {
            public ListEntry[] blacklist { get; set; }
            public static string JsonSerialaized(object lista) => JsonConvert.SerializeObject(lista);

            //Esegue la scrittura su disco di una stringa
            public static bool WriteJson(string JsonPath, string JsonBuffer)
            {
                try
                {
                    File.WriteAllText(JsonPath, JsonBuffer);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public class ListEntry
            {
                public string email { get; set; }
            }
        }
    }
}