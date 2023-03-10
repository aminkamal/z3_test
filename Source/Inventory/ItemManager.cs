using Z3Test.Persistence;
using Z3Test.Models;

namespace Z3Test
{
    namespace Inventory
    {
        public class ItemManager
        {
            private IDataStore<User> userStore;

            private IDataStore<PurchasableItem> purchasableItemsStore;

            public ItemManager(IDataStore<User> userStore, IDataStore<PurchasableItem> purchasableItemsStore)
            {
                this.userStore = userStore;
                this.purchasableItemsStore = purchasableItemsStore;
            }

            public bool PurchaseItem(string userID, string itemID)
            {
                // Check that the shop item exists
                var purchasableItem = purchasableItemsStore.Get(itemID);
                if (purchasableItem == null)
                {
                    return false;
                }

                // Check that the user has enough currency
                var user = userStore.Get(userID);

                // TODO: Extract gems into a constant
                var gemItem = user.Items.Find(x => x.ID == "gems");

                // Check the user has enough gem currency to buy the item
                if (purchasableItem.PriceGems != null && gemItem.Quantity >= purchasableItem.PriceGems)
                {
                    //
                    // TODO: In a real application these would be part of a transaction
                    //
                    user.Items.Add(new Item{
                        ID = purchasableItem.ID,
                        AcquiredOn = DateTime.Now,
                        Description = purchasableItem.Description,
                        Quantity = purchasableItem.Quantity,
                        Rarity = purchasableItem.Rarity,
                        Type = purchasableItem.Type
                    });

                    gemItem.Quantity -= purchasableItem.PriceGems.Value;
                }

                // TODO: return reason, e.g item not found, not enough currency, cannot buy with gems..etc
                return false;
            }
        }
    }
}
