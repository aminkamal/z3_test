using System.Net;

namespace Z3Test
{
    namespace Server
    {
        public delegate void RequestHandler(HttpListenerContext ctx);

        public static partial class Router
        {
            static List<Route> routes = new List<Route>();

            public static void Handle(HttpListenerContext ctx)
            {
                var request = ctx.Request;
                var method = request.HttpMethod;
                var path = request.Url.AbsolutePath;

                try
                {
                    var route = routes.First(x => x.path == path && x.method == method);
                    route.handler(ctx);
                }
                catch (InvalidOperationException)
                {
                    // TODO: 404
                }
            }
        }
    }
}
