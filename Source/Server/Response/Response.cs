using System.Net;
using System.Text;
using System.Text.Json;

namespace Z3Test
{
    namespace Server
    {
        public static class Response
        {
            public static async Task Write(HttpListenerContext ctx, int responseCode, object? response = null)
            {
                HttpListenerResponse resp = ctx.Response;

                resp.StatusCode = responseCode;
                resp.ContentType = "application/json";

                string json = "";
                if (response != null)
                {
                    json = JsonSerializer.Serialize(response);
                }

                byte[] data = Encoding.UTF8.GetBytes(json);
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }
    }
}
