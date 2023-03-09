using System.Net;
using Z3Test.Application;

namespace Z3Test
{
    namespace Server
    {
        public delegate void RequestHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> UrlParams = null);

        public struct Route
        {
            public string method { get; set; }

            public string path { get; set; }

            public RequestHandler handler { get; set; }

            public bool IsPublic { get; set; }

            public Route(string method, string path, RequestHandler handler, bool isPublic = false)
            {
                this.method = method;
                this.path = path;
                this.handler = handler;
                this.IsPublic = isPublic;
            }
        }
    }
}
