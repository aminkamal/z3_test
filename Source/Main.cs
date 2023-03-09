using Z3Test.Server;

namespace Z3Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Initialize server
            // TODO: Read this from .env files or environment variables
            var server = new HttpServer();
            server.Initialize("http://localhost:8000/");

            // Handle requests
            Task listenTask = server.HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            server.Shutdown();
        }
    }
}
