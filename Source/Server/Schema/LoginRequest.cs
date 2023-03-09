using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Server
    {
        namespace Schema
        {
            public class LoginRequest
            {
                [JsonPropertyName("username")]
                public string Username { get; set; }

                [JsonPropertyName("password")]
                public string Password { get; set; }
            }
        }
    }
}
