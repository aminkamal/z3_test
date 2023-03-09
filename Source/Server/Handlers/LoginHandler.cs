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
            public static async void LoginHandler(ApplicationContext appCtx, HttpListenerContext ctx, List<string> UrlParams = null)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var loginRequest = JsonSerializer.Deserialize<LoginRequest>(req);

                var accessToken = appCtx.accountManager.Login(loginRequest.Username, loginRequest.Password);
                if (accessToken != null)
                {
                    await Response.Write(ctx, 200, new LoginResponse { AccessToken = accessToken.ID, UserID = accessToken.UserID });
                }
                else
                {
                    // TODO: Write errors
                }
            }
        }
    }
}
