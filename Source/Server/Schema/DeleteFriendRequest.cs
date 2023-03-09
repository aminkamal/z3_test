using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Server
    {
        namespace Schema
        {
            public class DeleteFriendRequest
            {
                [JsonPropertyName("friend_id")]
                public string FriendID { get; set; }
            }
        }
    }
}
