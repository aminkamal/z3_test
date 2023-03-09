
namespace Z3Test
{
    namespace Server
    {
        public partial class Router
        {
            public void AddRoutes()
            {
                // Session
                routes.Add(new Route { method = "POST", path = "/login", handler = Handler.LoginHandler, IsPublic = true });

                // User
                routes.Add(new Route { method = "POST", path = "/users", handler = Handler.CreateUserHandler, IsPublic = true });
                routes.Add(new Route { method = "GET", path = "/users/<param1>", handler = Handler.GetUserHandler });

                // User friends
                routes.Add(new Route { method = "POST", path = "/users/<param1>/friends", handler = Handler.AddUserFriendHandler });
                routes.Add(new Route { method = "GET", path = "/users/<param1>/friends", handler = Handler.GetUserFriendsHandler });
                routes.Add(new Route { method = "DELETE", path = "/users/<param1>/friends", handler = Handler.DeleteUserFriendHandler });
                
                // User inventory
                //routes.Add(new Route { method = "POST", path = "/users/<param1>/items", handler = Handler.GrantItemHandler });
                //routes.Add(new Route { method = "GET", path = "/users/<param1>/items", handler = Handler.GetUserInventory });
                
                // Shop
                //routes.Add(new Route { method = "GET", path = "/purchasable-items", handler = Handler.GetPurchasableItems });


            }
        }
    }
}
