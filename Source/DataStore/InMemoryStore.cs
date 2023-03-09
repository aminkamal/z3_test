namespace Z3Test
{
    namespace Persistence
    {
        public class InMemoryStore<T> : IDataStore<T>
        {
            private Dictionary<string, T> store;

            private readonly string ID_FIELD_NAME = "ID";

            public InMemoryStore()
            {
                store = new Dictionary<string, T>();
            }

            public void Add(T item)
            {
                store.Add(
                    item.GetType().GetProperty(ID_FIELD_NAME).GetValue(item).ToString(),
                    item
                );
            }

            public void Set(T item)
            {
                var itemID = item.GetType().GetProperty(ID_FIELD_NAME).GetValue(item).ToString();
                store[itemID] = item;
            }

            public T[] List()
            {
                return store.Values.ToArray();
            }

            public KeyValuePair<string, T> Find(Func<KeyValuePair<string, T>, bool> expression)
            {
                return store.First(expression);
            }

            public T Get(string ID)
            {
                // TODO: This throws an error if an item was not found
                return store[ID];
            }

            public bool Delete(string ID)
            {
                return store.Remove(ID);
            }
        }
    }
}
