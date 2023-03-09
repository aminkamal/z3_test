using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Server
    {
        namespace Schema
        {
            public class AddFriendRequest
            {
                [JsonPropertyName("friend_id")]
                public string FriendID { get; set; }
            }
        }
    }
}
