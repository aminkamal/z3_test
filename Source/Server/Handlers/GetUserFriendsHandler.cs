using System.Net;
using System.Text.Json;
using Z3Test.Server.Schema;
using Z3Test.Application;

namespace Z3Test
{
    namespace Server
    {
        public static partial class Handler
        {
            public static async void GetUserFriendsHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();

                var user = appCtx.accountManager.GetUser(urlParams[0]);

                await Response.Write(ctx, 200, user.Friends);
            }
        }
    }
}
