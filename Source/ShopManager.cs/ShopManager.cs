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
                purchasableItemsStore.Add(new PurchasableItem{ID="100", GrantItemID="gems_100", PriceRealMoney=500, Description="Pouch (100 Gems)", Quantity=100, Rarity=1,Type=ItemType.GEM});
                purchasableItemsStore.Add(new PurchasableItem{ID="101", GrantItemID="gems_300", PriceRealMoney=900, Description="Chest (300 Gems)", Quantity=300, Rarity=1,Type=ItemType.GEM});
                purchasableItemsStore.Add(new PurchasableItem{ID="102", GrantItemID="gems_5000", PriceRealMoney=12000, Description="Ultra pack (5000 gems)", Quantity=5000, Rarity=1,Type=ItemType.GEM});
                purchasableItemsStore.Add(new PurchasableItem{ID="200", GrantItemID="base_warrior", PriceGems=500, Description="Warrior (Melee)", Quantity=1, Rarity=1,Type=ItemType.GEM});
                purchasableItemsStore.Add(new PurchasableItem{ID="300", GrantItemID="base_warrior_axe", PriceGems=300, Description="Axe for Warrior (Melee)", Quantity=3, Rarity=1,Type=ItemType.WEAPON});
                purchasableItemsStore.Add(new PurchasableItem{ID="201", GrantItemID="base_archer", PriceGems=500, Description="Archer (Ranged)", Quantity=1, Rarity=2,Type=ItemType.UNIT});
            }

            public PurchasableItem[] ListItems()
            {
                return purchasableItemsStore.List();
            }
        }
    }
}
