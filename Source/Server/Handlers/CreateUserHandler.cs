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
            public static async void CreateUserHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> UrlParams, AccessToken accessToken)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var createAccountRequest = JsonSerializer.Deserialize<CreateAccountRequest>(req);

                var result = appCtx.accountManager.CreateNew(createAccountRequest.Username, createAccountRequest.Password);

                await Response.Write(ctx, result ? 201 : 400, new GenericResponse { Success = result });
            }
        }
    }
}
