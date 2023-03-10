using Z3Test.Persistence;
using Z3Test.Models;
using Z3Test.Identity;
using Z3Test.Inventory;

namespace Z3Test
{
    namespace Application
    {
        public class ApplicationContext
        {
            public UserManager accountManager;

            public ItemManager itemManager;

            public ShopManager shopManager;

            public AccessTokenManager accessTokenManager;

            public ApplicationContext()
            {
                var userStore = new InMemoryStore<User>();
                
                var accessTokenStore = new InMemoryStore<AccessToken>();
                
                var purchasableItemsStore = new InMemoryStore<PurchasableItem>();

                accountManager = new UserManager(userStore, accessTokenStore);

                itemManager = new ItemManager(userStore);

                shopManager = new ShopManager(purchasableItemsStore);

                accessTokenManager = new AccessTokenManager(accessTokenStore);
            }
        }
    }
}
