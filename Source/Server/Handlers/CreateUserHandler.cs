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
            public static async void CreateUserHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> UrlParams = null)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var createAccountRequest = JsonSerializer.Deserialize<CreateAccountRequest>(req);

                appCtx.accountManager.CreateNew(createAccountRequest.Username, createAccountRequest.Password);

                await Response.Write(ctx, 201, new GenericResponse { Success = true });
            }
        }
    }
}
