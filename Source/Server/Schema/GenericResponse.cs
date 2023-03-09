using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Server
    {
        namespace Schema
        {
            public class GenericResponse
            {
                [JsonPropertyName("success")]
                public bool Success { get; set; }

                [JsonPropertyName("error")]
                public string Error { get; set; }
            }
        }
    }
}
