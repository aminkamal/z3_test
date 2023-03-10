using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Server
    {
        namespace Schema
        {
            public class GrantUserItemRequest
            {
                [JsonPropertyName("item_id")]
                public string ItemID { get; set; }
            }
        }
    }
}
