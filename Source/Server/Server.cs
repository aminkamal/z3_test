using System.Net;
using Z3Test.Application;

namespace Z3Test
{
    namespace Server
    {
        public partial class HttpServer
        {
            public HttpListener listener;

            private Router router;

            private ApplicationContext appCtx;

            public void Initialize(string url)
            {
                // Create a Http server and start listening for incoming connections
                listener = new HttpListener();
                listener.Prefixes.Add(url);
                listener.Start();

                // Initialize dependencies
                router = new Router();
                router.AddRoutes();

                appCtx = new ApplicationContext();

                Console.WriteLine("Listening for connections on {0}", url);
            }

            public void Shutdown()
            {
                // Close the listener
                listener.Close();
            }

            public async Task HandleIncomingConnections()
            {
                bool runServer = true;

                // While a user hasn't visited the `shutdown` url, keep on handling requests
                while (runServer)
                {
                    // Will wait here until we hear from a connection
                    HttpListenerContext ctx = await listener.GetContextAsync();
                    router.Handle(ctx);
                }
            }
        }
    }
}
