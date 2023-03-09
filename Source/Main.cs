using Z3Test.Server;

namespace Z3Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Initialize server
            HttpServer.Initialize("http://localhost:8000/");

            // Handle requests
            Task listenTask = HttpServer.HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            HttpServer.Shutdown();
        }
    }
}
