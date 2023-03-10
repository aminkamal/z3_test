using Z3Test.Persistence;
using Z3Test.Models;

namespace Z3Test
{
    namespace Identity
    {
        public class UserManager
        {
            private IDataStore<User> userStore;

            private IDataStore<AccessToken> accessTokenStore;

            public UserManager(IDataStore<User> userStore, IDataStore<AccessToken> accessTokenStore)
            {
                this.userStore = userStore;
                this.accessTokenStore = accessTokenStore;
            }

            private string generateUUID()
            {
                Guid uuid = Guid.NewGuid();
                return uuid.ToString();
            }

            public void CreateNew(string username, string password)
            {
                var defaultGemItem = new Item{
                    ID = "gems", // TODO: Extract gems into a constant
                    AcquiredOn = DateTime.Now,
                    Description = "The amount of premium currency you currently have",
                    Quantity = 1000,
                    Rarity = 1,
                    Type = ItemType.GEM
                };

                userStore.Add(new User
                {
                    ID = generateUUID(),
                    Name = username,
                    Password = password, // Obviously we hash this in a real application
                    IsBanned = false,
                    RegisteredOn = DateTime.Now,
                    Friends = new List<string>(),
                    Items = new List<Item>{defaultGemItem},
                    Platform = UserPlatform.WEB
                });
            }

            public User? GetUser(string userID)
            {
                try
                {
                    var user = userStore.Get(userID);
                    return user;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }

            public bool AddFriend(string userID, string friendID)
            {
                var user = GetUser(userID);

                // Check that the provided friend exists
                var friend = GetUser(friendID);
                if (friend == null)
                {
                    return false;
                }

                if (user != null)
                {
                    user.Friends.Add(friendID);
                    return true;
                }

                return false;
            }

            public bool DeleteFriend(string userID, string friendID)
            {
                var user = GetUser(userID);
                if (user != null)
                {
                    user.Friends = user.Friends.Where(x => x != friendID).ToList();
                    return true;
                }

                return false;
            }

            public AccessToken? Login(string username, string password)
            {
                try
                {
                    var user = userStore.Find(x => x.Value.Name == username && x.Value.Password == password);
                    var accessToken = new AccessToken{ ID = generateUUID(), UserID = user.Value.ID };
                    accessTokenStore.Add(accessToken);
                    return accessToken;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }
    }
}
