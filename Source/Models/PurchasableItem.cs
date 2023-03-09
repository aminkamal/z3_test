using System.Net;
using System.Text.Json;
using Z3Test.Server.Schema;

namespace Z3Test
{
    namespace Models
    {
        public class PurchasableItem
        {
            public string ID { get; set; }

            public int Price { get; set; }

            public string GrantItemID { get; set; }
        }
    }
}
