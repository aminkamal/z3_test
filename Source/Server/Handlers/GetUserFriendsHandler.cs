using System.Net;
using Z3Test.Server.Schema;
using Z3Test.Application;
using Z3Test.Models;

namespace Z3Test
{
    namespace Server
    {
        public static partial class Handler
        {
            public static async void GetUserFriendsHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams, AccessToken accessToken)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();

                var userID = urlParams[0];
                if (userID != accessToken.UserID)
                {
                    await Response.Write(ctx, 403, new GenericResponse { Success = false, Error = "forbidden" });
                    return;
                }

                var user = appCtx.accountManager.GetUser(userID);

                await Response.Write(ctx, 200, user.Friends);
            }
        }
    }
}
