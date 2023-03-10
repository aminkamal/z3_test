using System.Net;
using System.Text.Json;
using Z3Test.Server.Schema;

namespace Z3Test
{
    namespace Models
    {
        public class PurchasableItem : Item
        {
            public int? PriceRealMoney { get; set; }
            
            public int? PriceGems { get; set; }

            public string GrantItemID { get; set; }
        }
    }
}
