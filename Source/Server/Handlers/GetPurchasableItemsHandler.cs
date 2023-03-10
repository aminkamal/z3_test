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
            public static async void GetPurchasableItemsHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> urlParams, AccessToken accessToken)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();

                var items = appCtx.shopManager.ListItems();

                await Response.Write(ctx, 200, items);
            }
        }
    }
}
