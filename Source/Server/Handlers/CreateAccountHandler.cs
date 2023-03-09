using System.Net;
using System.Text.Json;
using Z3Test.Server.Schema;

namespace Z3Test
{
    namespace Server
    {
        public static partial class Handler
        {
            public static void CreateAccountHandler(HttpListenerContext ctx)
            {
                var req = new StreamReader(ctx.Request.InputStream).ReadToEnd();
                var mod = JsonSerializer.Deserialize<CreateAccountRequest>(req);

                Console.WriteLine(mod.Username);
                Console.WriteLine(mod.Password);
            }
        }
    }
}
