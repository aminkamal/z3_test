using System.Net;
using System.Text;

namespace Z3Test
{
    namespace Server
    {
        static partial class HttpServer
        {
            public static HttpListener listener;

            public static void Initialize(string url)
            {
                // Create a Http server and start listening for incoming connections
                listener = new HttpListener();
                listener.Prefixes.Add(url);
                listener.Start();

                Router.AddRoutes();

                Console.WriteLine("Listening for connections on {0}", url);
            }

            public static void Shutdown()
            {
                // Close the listener
                listener.Close();
            }

            public static async Task HandleIncomingConnections()
            {
                bool runServer = true;

                // While a user hasn't visited the `shutdown` url, keep on handling requests
                while (runServer)
                {
                    // Will wait here until we hear from a connection
                    HttpListenerContext ctx = await listener.GetContextAsync();
                    Router.Handle(ctx);
                }
            }
        }
    }
}
