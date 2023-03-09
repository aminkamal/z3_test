using System.Net;

namespace Z3Test
{
    namespace Server
    {
        public struct Route
        {
            public Route(string method, string path, RequestHandler handler)
            {
                this.method = method;
                this.path = path;
                this.handler = handler;
            }

            public string method { get; set; }
            public string path { get; set; }
            public RequestHandler handler { get; set; }
        }
    }
}
