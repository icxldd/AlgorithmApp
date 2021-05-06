using System;
using DataStructure.DataStructure;

namespace DataStructure.Trees
{
    /// <summary>
    /// 红黑树
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class RBTree<K, V> : Map<K, V> where K : IComparable<K>
    {
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;
        
        private class Node
        {
            public K key { get; set; }
            public V value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                Left = null;
                Right = null;
                Color = RED;
            }
        }

        private Node _root;
        private int _size;

        public RBTree()
        {
            _root = null;
            _size = 0;
        }

        /// <summary>
        /// 是否是红节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool isRed(Node node)
        {
            if (node==null)
            {
                return BLACK;
            }
            else
            {
                return node.Color;
            }
        }

        /// <summary>
        /// 颜色翻转
        /// </summary>
        /// <param name="node"></param>
        private void flipColors(Node node)
        {
            node.Color = RED;
            node.Left.Color = BLACK;
            node.Right.Color = BLACK;
        }


        private Node rightRotate(Node node)
        {
            Node x = node.Left;

            //右旋转
            node.Left = x.Right;
            x.Right = node;

            x.Color = node.Color;
            node.Color = RED;
            return x;
        }

        private Node leftRotate(Node node)
        {
            Node x = node.Right;
            //左旋转
            node.Right = x.Left;
            x.Left = node;

            x.Color = node.Color;
            node.Color = RED;
            
            return x;
        }

        /// <summary>
        /// 向红黑树中添加元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void add(K key, V value)
        {
            _root = add(_root, key, value);
            _root.Color = BLACK;//最终根节点 是 黑色
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


            if (isRed(node.Right)&& !isRed(node.Left))
            {
                node = leftRotate(node);
            }
            if (isRed(node.Left) && isRed(node.Left.Left))
            {
                node = rightRotate(node);
            }
            if (isRed(node.Left) && isRed(node.Right))
            {
                flipColors(node);
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