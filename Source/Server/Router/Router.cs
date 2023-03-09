using System.Net;
using Z3Test.Application;
using Z3Test.Server.Schema;

namespace Z3Test
{
    namespace Server
    {
        public partial class Router
        {
            private List<Route> routes { get; set; }

            private ApplicationContext appCtx;

            public Router()
            {
                routes = new List<Route>();
                appCtx = new ApplicationContext();
            }

            public async void Handle(HttpListenerContext ctx)
            {
                var request = ctx.Request;
                var method = request.HttpMethod;
                var path = request.Url.AbsolutePath;

                try
                {
                    var pathToFind = "";
                    var urlSegments = path.Substring(1).Split('/');
                    var urlParams = new List<string>();

                    for (int i = 0; i < urlSegments.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            urlParams.Add(urlSegments[i]);
                            pathToFind += $"/<param{urlParams.Count}>";
                        }
                        else
                        {
                            pathToFind += $"/{urlSegments[i]}";
                        }
                    }

                    var matchingRoute = routes.Find(x => x.path == pathToFind && x.method == method);

                    if (!matchingRoute.IsPublic!)
                    {
                        var result = Middleware.Authentication(appCtx, ctx);
                        if (!result)
                        {
                            await Response.Write(ctx, 401, new GenericResponse { Success = false, Error = "unauthorized" });
                            return;
                        }
                    }

                    matchingRoute.handler(appCtx, ctx, urlParams);
                }
                catch (InvalidOperationException)
                {
                    // TODO: 404
                }
            }
        }
    }
}
