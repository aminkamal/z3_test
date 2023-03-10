using System.Net;
using Z3Test.Application;
using Z3Test.Models;

namespace Z3Test
{
    namespace Server
    {
        public static class Middleware
        {
            public static AccessToken? Authentication(ApplicationContext appCtx, HttpListenerContext ctx)
            {
                var authorizationHeader = ctx.Request.Headers.Get("Authorization");
                if (authorizationHeader != null)
                {
                    var accessToken = appCtx.accessTokenManager.Get(authorizationHeader);
                    return accessToken;
                }

                return null;
            }
        }
    }
}
