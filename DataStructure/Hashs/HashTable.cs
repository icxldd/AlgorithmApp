using System;
using System.Collections.Generic;

namespace DataStructure.Hashs
{
    public class HashTable<K, V>
    {
        private List<Dictionary<K, V>> hashtable;
        private int M;
        private int size;
        public HashTable(int M)
        {
            this.M = M;
            size = 0;
            hashtable = new List<Dictionary<K, V>>(this.M);
            for (int i = 0; i < this.M; i++)
            {
                hashtable[i] = new Dictionary<K, V>();
            }
        }
        public HashTable() : this(97)
        {
        }
        private int hash(K key)
        {
            return Math.Abs(key.GetHashCode()) % this.M;
        }

        public int getSize()
        {
            return size;
        }

        public void add(K key, V value)
        {
            Dictionary<K, V> map = hashtable[hash(key)];
            if (map.ContainsKey(key))
            {
                map[key] = value;
            }
            else
            {
                map[key] = value;
                size++;
            }
        }
        public V remove(K key)
        {
            Dictionary<K, V> map = hashtable[hash(key)];
            V ret = default;
            if (map.ContainsKey(key))
            {
                ret = map[key];
                map.Remove(key);
            }

            return ret;
        }
        public void set(K key, V value)
        {
            Dictionary<K, V> map = hashtable[hash(key)];
            if (!map.ContainsKey(key))
            {
                throw new Exception("not found!");
            }

            map[key] = value;
        }
        public bool contains(K key)
        {
            return hashtable[hash(key)].ContainsKey(key);
        }
        public V get(K key)
        {
            return hashtable[hash(key)][key];
        }
    }
}