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
            public static async void AddUserFriendHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var addFriendRequest = JsonSerializer.Deserialize<AddFriendRequest>(req);

                var result = appCtx.accountManager.AddFriend(urlParams[0], addFriendRequest.FriendID);

                await Response.Write(ctx, result ? 200 : 400, new GenericResponse { Success = result });
            }
        }
    }
}
