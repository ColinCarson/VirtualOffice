namespace SlackLink
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using Newtonsoft.Json.Linq;

    public class SlackLink
    {
        private const string token = "eG94cC0xMTkzMjczNTMxNjAzLTEyMTY5MDEzMzUyNjQtMTE4NzQzMTAwMzA2Mi04NzA5NjcyY2JjZmY2OTBlZGI2NTI2ZGE5NGJlN2I1NQ==";

        public IEnumerable<string> GetUsers()
        {
            var webClient = new WebClient();
            webClient.QueryString.Add("token", DecodeToken(token));
            var result = webClient.DownloadString("	https://slack.com/api/users.list");
            var content = JObject.Parse(result);

            return new List<string> { "Rod", "Jane", "Freddy" };
        }

        public IEnumerable<string> GetChannels()
        {
            var webClient = new WebClient();
            webClient.QueryString.Add("token", DecodeToken(token));
            var result = webClient.DownloadString("	https://slack.com/api/users.list");
            var content = JObject.Parse(result);


            return new List<string> { "General", "Chat", "Food" };
        }        

        public SlackUser GetUserStatus(string userId)
        {
            var webClient = new WebClient();
            webClient.QueryString.Add("token", DecodeToken(token));
            webClient.QueryString.Add("user", userId);
            var profileResult = webClient.DownloadString("	https://slack.com/api/users.profile.get");
            var profileContent = JObject.Parse(profileResult);

            var displayName = (string)profileContent["profile"]["display_name"];
            var status = (string)profileContent["profile"]["status_text"];

            webClient = new WebClient();
            webClient.QueryString.Add("token", DecodeToken(token));
            webClient.QueryString.Add("user", userId);
            var presenceResult = webClient.DownloadString("	https://slack.com/api/users.getPresence");
            var presenceContent = JObject.Parse(presenceResult);

            var online = false;
            var active = (string)presenceContent["presence"];

            if (active != "away")
            { 
                online = (bool)presenceContent["online"];
            }            

            return new SlackUser { Name = displayName, Id = userId, Status = status, Active = active, Online = online};            
        }

        public void SendMessage(string target, string text)
        {
            var data = new NameValueCollection();
            data["token"] = DecodeToken(token);
            data["channel"] = target;   
            data["text"] = text;
            
            var webClient = new WebClient();
            webClient.UploadValues("https://slack.com/api/chat.postMessage", "POST", data);
        }       

        public void StartZoomCall(string target, string userId, string message, string zoomUrl)
        {
            var text = $"<{userId}> {message} {zoomUrl}";
            SendMessage(target, text);
        }

        private string DecodeToken(string token)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(token);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

    public class SlackUser
    {
        public string Name;
        public string Id;
        public string Status;
        public string Active;
        public bool Online;        
    }

}
