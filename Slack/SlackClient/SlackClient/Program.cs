namespace SlackLink
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var slackLink = new SlackLink();

            //slackLink.SendMessageToChannel("#random", "Hello from the bot!", "USLACKBOT", "");

            //var users = slackLink.GetUsers();

            //var user = slackLink.GetUserStatus("U016CSH9V7S");

            Console.Write("Press any key to exit");
            Console.ReadLine();
        }
    }
}