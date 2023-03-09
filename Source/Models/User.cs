using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Models
    {
        public enum UserPlatform { WEB, IOS, ANDROID }

        public class User
        {
            public string ID { get; set; }

            public string Name { get; set; }
            
            [JsonIgnore]
            public string Password { get; set; }

            public bool IsBanned { get; set; }

            [JsonConverter(typeof(JsonStringEnumConverter))]
            public UserPlatform Platform { get; set; }

            public DateTime RegisteredOn { get; set; }

            public List<Item> Items { get; set; }
            
            public List<string> Friends { get; set; }
        }
    }
}
