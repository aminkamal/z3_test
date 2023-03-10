using Z3Test.Persistence;
using Z3Test.Models;

namespace Z3Test
{
    namespace Inventory
    {
        public class ItemManager
        {
            private IDataStore<User> userStore;

            public ItemManager(IDataStore<User> userStore)
            {
                this.userStore = userStore;
            }
        }
    }
}
