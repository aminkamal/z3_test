
namespace Z3Test
{
    namespace Server
    {
        public static partial class Router
        {
            public static void AddRoutes()
            {
                routes.Add(new Route { method = "POST", path = "/users", handler = Handler.CreateAccountHandler });
            }
        }
    }
}
