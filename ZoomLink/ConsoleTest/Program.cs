namespace ConsoleTest
{
    using System;
    using System.Threading.Tasks;
    using ZoomClient;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating zoom call...");
            var zoomClient = new ZoomClient();
            zoomClient.JoinMeeting("Test", "3481207951", "6FvNXv");
            //Zoom().Wait();

            Console.Write("Press any key to exit");
            Console.ReadLine();
        }

        static async Task Zoom()
        {
            var zoomClient = new ZoomClient();
            await new Task(() => { zoomClient.JoinMeeting("Test", "3481207951", "6FvNXv"); });
        }
    }
}
