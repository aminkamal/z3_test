namespace Z3Test
{
    namespace Persistence
    {
        public interface IDataStore<T>
        {
            public void Add(T item);

            public T[] List();

            public T Get(string ID);

            public void Set(T item);

            public bool Delete(string ID);

            public KeyValuePair<string, T> Find(Func<KeyValuePair<string, T>, bool> expression);
        }
    }
}
