using System;
using System.Collections.Generic;
using DataStructure.DataStructure;

namespace DataStructure.Trees
{
    public class AvlTree<K, V> : Map<K, V> where K : IComparable<K>
    {
        private class Node
        {
            public K key { get; set; }
            public V value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                Left = null;
                Right = null;
                Height = 1;
            }
        }

        private Node _root;
        private int _size;

        public AvlTree()
        {
            _root = null;
            _size = 0;
        }

        private int getHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
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

            //更新height；
            node.Height = 1 + Math.Max(getHeight(node.Left), getHeight(node.Right));
            //计算平衡因子
            int balanceFactor = getBalanceFactor(node);
            //平衡维护 右旋转LL
            if (balanceFactor > 1 && getBalanceFactor(node.Left) >= 0)
            {
                return rightRotate(node);
            }

            //左旋转RR
            if (balanceFactor < -1 && getBalanceFactor(node.Right) <= 0)
            {
                return rightRotate(node);
            }

            //LR
            if (balanceFactor > 1 && getBalanceFactor(node.Left) < 0)
            {
                node.Left = leftRotate(node.Left);
                return rightRotate(node);
            }

            //RL
            if (balanceFactor < -1 && getBalanceFactor(node.Right) > 0)
            {
                node.Right = rightRotate(node.Right);
                return leftRotate(node);
            }

            return node;
        }

        private Node leftRotate(Node y)
        {
            Node x = y.Right;
            Node t2 = x.Left;

            //向左旋转
            x.Left = y;
            y.Right = t2;

            //更新height
            y.Height = Math.Max(getHeight(y.Left), getHeight(y.Right)) + 1;
            x.Height = Math.Max(getHeight(x.Left), getHeight(x.Right)) + 1;
            return x;
        }

        /// <summary>
        /// 右旋转
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private Node rightRotate(Node y)
        {
            Node x = y.Left;
            Node t3 = x.Right;
            x.Right = y;
            y.Left = t3;

            //更新height
            y.Height = Math.Max(getHeight(y.Left), getHeight(y.Right)) + 1;
            x.Height = Math.Max(getHeight(x.Left), getHeight(x.Right)) + 1;

            return x;
        }

        public bool isBST()
        {
            List<K> keys = new List<K>();
            inOrder(_root, keys);
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i - 1].CompareTo(keys[i]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool isBalanced()
        {
            return isBalanced(_root);
        }

        private bool isBalanced(Node node)
        {
            if (node == null)
            {
                return true;
            }

            int balanceFactor = getBalanceFactor(node);

            if (Math.Abs(balanceFactor) > 1)
            {
                return false;
            }

            return isBalanced(node.Left) && isBalanced(node.Right);
        }

        private void inOrder(Node node, List<K> keys)
        {
            if (node == null)
            {
                return;
            }

            inOrder(node.Left, keys);
            keys.Add(node.key);
            inOrder(node.Right, keys);
        }

        /// <summary>
        /// 获取节点平衡因子
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int getBalanceFactor(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return getHeight(node.Left) - getHeight(node.Right);
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

            Node retNode;
            if (key.CompareTo(node.key) < 0)
            {
                node.Left = remove(node.Left, key);
                retNode = node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.Right = remove(node.Right, key);
                retNode = node;
            }
            else
            {
                if (node.Left == null)
                {
                    Node rightNode = node.Right;
                    node.Right = null;
                    _size--;
                    retNode = rightNode;
                }

                if (node.Right == null)
                {
                    Node leftNode = node.Left;
                    node.Left = null;
                    _size--;
                    retNode = leftNode;
                }
                else
                {
                    Node successor = minimum(node.Right);
                    successor.Right = remove(node.Right, successor.key);
                    successor.Left = node.Left;
                    node.Left = node.Right = null;
                    retNode = successor;
                }
            }


            if (retNode==null)
            {
                return null;
            }
            
            //更新height；
            retNode.Height = 1 + Math.Max(getHeight(retNode.Left), getHeight(retNode.Right));
            //计算平衡因子
            int balanceFactor = getBalanceFactor(retNode);
            //平衡维护 右旋转LL
            if (balanceFactor > 1 && getBalanceFactor(retNode.Left) >= 0)
            {
                return rightRotate(retNode);
            }

            //左旋转RR
            if (balanceFactor < -1 && getBalanceFactor(retNode.Right) <= 0)
            {
                return rightRotate(retNode);
            }

            //LR
            if (balanceFactor > 1 && getBalanceFactor(retNode.Left) < 0)
            {
                retNode.Left = leftRotate(retNode.Left);
                return rightRotate(retNode);
            }

            //RL
            if (balanceFactor < -1 && getBalanceFactor(retNode.Right) > 0)
            {
                retNode.Right = rightRotate(retNode.Right);
                return leftRotate(retNode);
            }

            return retNode;
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