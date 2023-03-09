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
            public static async void DeleteUserFriendHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var deleteFriendRequest = JsonSerializer.Deserialize<DeleteFriendRequest>(req);

                var result = appCtx.accountManager.DeleteFriend(urlParams[0], deleteFriendRequest.FriendID);

                await Response.Write(ctx, result ? 200 : 400, new GenericResponse { Success = result });
            }
        }
    }
}
