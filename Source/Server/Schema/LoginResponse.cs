using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Server
    {
        namespace Schema
        {
            public class LoginResponse
            {
                [JsonPropertyName("access_token")]
                public string AccessToken { get; set; }

                [JsonPropertyName("user_id")]
                public string UserID { get; set; }
            }
        }
    }
}
