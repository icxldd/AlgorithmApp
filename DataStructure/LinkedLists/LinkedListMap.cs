using System;
using DataStructure.DataStructure;

namespace DataStructure.LinkedLists
{
    public class LinkedListMap<K, V> : Map<K, V>
    {
        private class Node
        {
            public K key { get; set; }
            public V value { get; set; }

            public Node next { get; set; }

            public Node(K key, V value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }

            public Node(K key)
            {
                this.key = key;
                this.value = default(V);
                this.next = null;
            }

            public Node()
            {
            }

            public override string ToString()
            {
                return key.ToString() + ":" + value.ToString();
            }
        }

        private Node _dummyHead;
        private int _size;

        public LinkedListMap()
        {
            _dummyHead = new Node();
            _size = 0;
        }

        private Node getNode(K key)
        {
            Node cur = _dummyHead.next;
            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return cur;
                }

                cur = cur.next;
            }

            return null;
        }

        public void add(K key, V value)
        {
            Node node = getNode(key);
            if (node == null)
            {
                _dummyHead.next = new Node(key, value, _dummyHead.next);
                _size++;
            }
            else
            {
                node.value = value;
            }
        }

        public V remove(K key)
        {
            Node prev = _dummyHead;
            while (prev.next != null)
            {
                if (prev.next.key.Equals(key))
                {
                    break;
                }

                prev = prev.next;
            }

            if (prev.next != null)
            {
                Node delNode = prev.next;
                prev.next = delNode.next;
                delNode.next = null;
                return delNode.value;
            }

            return default(V);
        }

        public bool contains(K key)
        {
            return getNode(key) != null;
        }

        public V get(K key)
        {
            Node node = getNode(key);
            return node == null ? default(V) : node.value;
        }

        public void set(K key, V value)
        {
            Node node = getNode(key);

            if (node == null)
            {
                throw new Exception("doesn't exist!");
            }

            node.value = value;
        }

        public int getSize()
        {
            return _size;
        }

        public bool isEmpty()
        {
            return _size == 0;
        }
    }
}