namespace SlackLink
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var slackLink = new SlackLink();

            slackLink.StartZoomCall("#random", "@U015W8DN5KN", "Fancy a video call?", "https://us04web.zoom.us/j/3481207951?pwd=S2VINDFNTUlVbHVFYmNsVXBlZ3pvUT09");


            //var users = slackLink.GetUsers();

            //var user = slackLink.GetUserStatus("U0162MFLDLZ");            

            Console.Write("Press any key to exit");
            Console.ReadLine();
        }
    }
}