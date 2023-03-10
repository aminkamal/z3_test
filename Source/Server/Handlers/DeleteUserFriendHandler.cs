using System.Net;
using System.Text.Json;
using Z3Test.Server.Schema;
using Z3Test.Application;
using Z3Test.Models;

namespace Z3Test
{
    namespace Server
    {
        public static partial class Handler
        {
            public static async void DeleteUserFriendHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams, AccessToken accessToken)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var deleteFriendRequest = JsonSerializer.Deserialize<DeleteFriendRequest>(req);

                var userID = urlParams[0];
                if (userID != accessToken.UserID)
                {
                    await Response.Write(ctx, 403, new GenericResponse { Success = false, Error = "forbidden" });
                    return;
                }

                var result = appCtx.accountManager.DeleteFriend(userID, deleteFriendRequest.FriendID);

                await Response.Write(ctx, result ? 200 : 400, new GenericResponse { Success = result });
            }
        }
    }
}
