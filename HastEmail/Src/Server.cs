using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace HastEmail.Src
{

    public class ServerResponse
    {
        public ServerResponse()
        {

        }

        public bool Success;
    }

    public class Server
    {
        public Server()
        {

        }

        ~Server()
        {
            // None
        }

        public static readonly string MainUrl = "https://hastemailapi.herokuapp.com";

        public static readonly string LoginURL = MainUrl + "/login";

        public static readonly string CheckURL = MainUrl + "/check/";

        public static readonly string RemoveURL = MainUrl + "/delete/";

        public static readonly string AddURL = MainUrl + "/add/";

        public static readonly string ListURL = MainUrl + "/list/";

        public static string MakeRequest(User user, string HttpVerb, string EndPoint)
        {
            WebClient wc = new WebClient();
            wc.QueryString.Add("username", user.username);
            wc.QueryString.Add("password", user.password);

            try
            {
                byte[] data = wc.UploadValues(EndPoint, HttpVerb, wc.QueryString);
                string res = Encoding.UTF8.GetString(data);
                return res;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ECCEZIONE: {ex}");
                return null;
            }
        }

        public static string MakeRequest(string EndPoint)
        {
            HttpWebRequest request = WebRequest.CreateHttp(EndPoint);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}