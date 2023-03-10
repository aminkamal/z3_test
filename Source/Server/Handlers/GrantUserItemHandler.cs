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
            public static async void GrantUserItemHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams, AccessToken accessToken)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var grantUserItemRequest = JsonSerializer.Deserialize<GrantUserItemRequest>(req);

                var userID = urlParams[0];
                if (userID != accessToken.UserID)
                {
                    await Response.Write(ctx, 403, new GenericResponse { Success = false, Error = "forbidden" });
                    return;
                }

                var result = appCtx.itemManager.PurchaseItem(userID, grantUserItemRequest.ItemID);

                await Response.Write(ctx, result ? 200 : 400, new GenericResponse { Success = result });
            }
        }
    }
}
