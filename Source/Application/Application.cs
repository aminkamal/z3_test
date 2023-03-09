using System.Net;
using Z3Test.Persistence;
using Z3Test.Models;
using Z3Test.Identity;

namespace Z3Test
{
    namespace Application
    {
        public class ApplicationContext
        {
            public UserManager accountManager;

            public AccessTokenManager accessTokenManager;

            public ApplicationContext()
            {
                var userStore = new InMemoryStore<User>();
                
                var accessTokenStore = new InMemoryStore<AccessToken>();
                
                var purchasableItemsStore = new InMemoryStore<PurchasableItem>();

                accountManager = new UserManager(userStore, accessTokenStore);

                accessTokenManager = new AccessTokenManager(accessTokenStore);

                // Add some shop items
                purchasableItemsStore.Add(new PurchasableItem{ID="100", GrantItemID="gems_100", Price=900});
                purchasableItemsStore.Add(new PurchasableItem{ID="101", GrantItemID="gems_300", Price=900});
                purchasableItemsStore.Add(new PurchasableItem{ID="102", GrantItemID="gems_5000", Price=900});
                purchasableItemsStore.Add(new PurchasableItem{ID="200", GrantItemID="base_warrior", Price=500});
                purchasableItemsStore.Add(new PurchasableItem{ID="300", GrantItemID="base_warrior_axe", Price=300});
                purchasableItemsStore.Add(new PurchasableItem{ID="201", GrantItemID="base_archer", Price=500});
            }
        }
    }
}
