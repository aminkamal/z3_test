using Z3Test.Persistence;
using Z3Test.Models;

namespace Z3Test
{
    namespace Identity
    {
        public class AccessTokenManager
        {
            private IDataStore<AccessToken> accessTokenStore;

            public AccessTokenManager(IDataStore<AccessToken> accessTokenStore)
            {
                this.accessTokenStore = accessTokenStore;
            }

            public AccessToken? Get(string accessTokenID)
            {
                try
                {
                    // TODO: Also validate expiry
                    var accessToken = accessTokenStore.Get(accessTokenID);
                    return accessToken;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }

            public void Delete(string accessTokenID)
            {
                accessTokenStore.Delete(accessTokenID);
            }
        }
    }
}
