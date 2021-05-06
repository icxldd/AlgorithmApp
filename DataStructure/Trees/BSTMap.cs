using System;
using DataStructure.DataStructure;

namespace DataStructure.Trees
{
    
    public class BSTMap<K, V> : Map<K, V> where K : IComparable<K>
    {
        private class Node
        {
            public K key { get; set; }
            public V value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                Left = null;
                Right = null;
            }
        }

        private Node _root;
        private int _size;

        public BSTMap()
        {
            _root = null;
            _size = 0;
        }

        public void add(K key, V value)
        {
            _root = add(_root, key, value);
        }

        private Node add(Node node, K key, V value)
        {
            if (node == null)
            {
                _size++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) < 0)
            {
                node.Left = add(node.Left, key, value);
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.Right = add(node.Right, key, value);
            }
            else //相等  更新值
            {
                node.value = value;
            }

            return node;
        }

        /// <summary>
        /// 返回以node为根节点中  key所在的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node getNode(Node node, K key)
        {
            if (node == null)
            {
                return null;
            }

            if (key.CompareTo(node.key) == 0)
            {
                return node;
            }
            else if (key.CompareTo(node.key) < 0)
            {
                return getNode(node.Left, key);
            }
            else
            {
                return getNode(node.Right, key);
            }
        }

        public bool contains(K key)
        {
            return getNode(_root, key) != null;
        }

        public V get(K key)
        {
            return getNode(_root, key).value;
        }

        public void set(K key, V value)
        {
            getNode(_root, key).value = value;
        }

        public int getSize()
        {
            return _size;
        }

        public bool isEmpty()
        {
            return _size == 0;
        }


        public V remove(K key)
        {
            Node node = getNode(_root, key);
            if (node != null)
            {
                _root = remove(_root, key);
                return node.value;
            }

            return default;
        }

        private Node remove(Node node, K key)
        {
            if (node == null)
            {
                return null;
            }

            if (key.CompareTo(node.key) < 0)
            {
                node.Left = remove(node.Left, key);
                return node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.Right = remove(node.Right, key);
                return node;
            }
            else
            {
                if (node.Left == null)
                {
                    Node rightNode = node.Right;
                    node.Right = null;
                    _size--;
                    return rightNode;
                }

                if (node.Right == null)
                {
                    Node leftNode = node.Left;
                    node.Left = null;
                    _size--;
                    return leftNode;
                }

                Node successor = minimum(node.Right);
                successor.Right = removeMin(node.Right);
                successor.Left = node.Left;
                node.Left = node.Right = null;
                return successor;
            }
        }

        public K minimum()
        {
            if (_size == 0)
            {
                throw new Exception("tree is empty");
            }

            return minimum(_root).key;
        }

        private Node minimum(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return minimum(node.Left);
        }

        private K removeMin()
        {
            K ret = minimum();
            _root = removeMin(_root);
            return ret;
        }

        private Node removeMin(Node node)
        {
            if (node.Left == null) //到了最左边的值
            {
                Node rightNode = node.Right;
                node.Right = null;
                _size--;
                return rightNode;
            }

            node.Left = removeMin(node.Left);
            return node;
        }
    }
}