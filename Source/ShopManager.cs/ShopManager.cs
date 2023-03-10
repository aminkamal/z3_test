using Z3Test.Persistence;
using Z3Test.Models;

namespace Z3Test
{
    namespace Inventory
    {
        public class ShopManager
        {
            private IDataStore<PurchasableItem> purchasableItemsStore;

            public ShopManager(IDataStore<PurchasableItem> purchasableItemsStore)
            {
                this.purchasableItemsStore = purchasableItemsStore;

                // Add some shop items
                purchasableItemsStore.Add(new PurchasableItem{ID="100", GrantItemID="gems_100", Price=900});
                purchasableItemsStore.Add(new PurchasableItem{ID="101", GrantItemID="gems_300", Price=900});
                purchasableItemsStore.Add(new PurchasableItem{ID="102", GrantItemID="gems_5000", Price=900});
                purchasableItemsStore.Add(new PurchasableItem{ID="200", GrantItemID="base_warrior", Price=500});
                purchasableItemsStore.Add(new PurchasableItem{ID="300", GrantItemID="base_warrior_axe", Price=300});
                purchasableItemsStore.Add(new PurchasableItem{ID="201", GrantItemID="base_archer", Price=500});
            }

            public PurchasableItem[] ListItems()
            {
                return purchasableItemsStore.List();
            }
        }
    }
}
