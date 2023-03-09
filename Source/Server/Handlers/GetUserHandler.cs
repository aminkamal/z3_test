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
            public static async void GetUserHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();

                // TODO: Only allow users to get themselves if they're not an admin to prevent leaking
                // the details of other users
                var user = appCtx.accountManager.GetUser(urlParams[0]);

                // TODO: Map only the fields we want to show the user
                await Response.Write(ctx, 200, user);
            }
        }
    }
}
