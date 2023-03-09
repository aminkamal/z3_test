using System.Net;
using System.Text.Json;
using Z3Test.Server.Schema;
using Z3Test.Application;

namespace Z3Test
{
    namespace Server
    {
        public static class Middleware
        {
            public static bool Authentication(ApplicationContext appCtx, HttpListenerContext ctx, List<string> UrlParams = null)
            {
                var authorizationHeader = ctx.Request.Headers.Get("Authorization");
                if (authorizationHeader != null)
                {
                    var accessToken = appCtx.accessTokenManager.Get(authorizationHeader);
                    return true;
                }

                return false;
            }
        }
    }
}
