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
            var result = webClient.DownloadString("	https://slack.com/api/users.profile.get");
            var content = JObject.Parse(result);

            var displayName = (string)content["profile"]["display_name"];
            var status = (string)content["profile"]["status_text"];

            return new SlackUser { Name = displayName, Id = userId, Status = status };            
        }

        public void SendMessageToChannel(string channel, string text, string asUser, string username)
        {
            var data = new NameValueCollection();
            data["token"] = DecodeToken(token);
            data["channel"] = channel;
            data["as_user"] = asUser;           
            data["text"] = text;
            
            var webClient = new WebClient();
            var response = webClient.UploadValues("https://slack.com/api/chat.postMessage", "POST", data);
        }

        public void SendMessageToUser(string channel, string text, string asUser, string username)
        {
            var data = new NameValueCollection();
            data["token"] = DecodeToken(token);
            data["channel"] = channel;
            data["as_user"] = asUser;
            data["text"] = text;

            var webClient = new WebClient();
            var response = webClient.UploadValues("https://slack.com/api/chat.postMessage", "POST", data);
        }

        public void StartCall()
        {

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
    }

}
