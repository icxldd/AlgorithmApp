namespace DataStructure.DataStructure
{
    public interface Map<K, V>
    {
        void add(K key, V value);
        V remove(K key);
        bool contains(K key);
        V get(K key);
        void set(K key, V value);
        int getSize();
        bool isEmpty();
    }
}