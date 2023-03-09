using System.Text.Json.Serialization;

namespace Z3Test
{
    namespace Models
    {
        public enum ItemType { UNIT, GEM, ACHIVEMENT }

        public class Item
        {
            public string ID { get; set; }

            [JsonConverter(typeof(JsonStringEnumConverter))]
            public ItemType Type { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public int Rarity { get; set; }

            // Once acquired by a user, InstanceID and AquiredOn
            // will no longer be null
            public string InstanceID { get; set; }

            public DateTime AcquiredOn { get; set; }
        }
    }
}
