using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DataStructure.Trees
{
    public class Context : IComparable<Context>
    {
        public int Value { get; set; }

        public string Tag { get; set; }

        public Context(int value,string tag)
        {
            Value = value;
            Tag = tag;
        }

        public int CompareTo(Context other)
        {
            if (other.Value == this.Value)
            {
                return 0;
            }
            else if (this.Value > other.Value)
            {
                return 1;
            }
            else if (this.Value < other.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// 二分搜索树
    /// TODO:  1.二分搜索树不包含两个相同元素（把左，右孩子加上等于条件可以支持重复元素）
    /// 前序遍历： 1.访问根节点2.前序遍历左子树 3.前序遍历右子树 
    /// 中序遍历： 1.中序遍历左子树 2.访问根节点 3.中序遍历右子树 
    /// 后序遍历： 1.后序遍历左子树  2.后序遍历右子树 3.访问根节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BstBinaryTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        private Node _root;
        private int _size;

        public BstBinaryTree()
        {
            _root = null;
            _size = 0;
        }

        public int GetSize() => _size;
        public bool IsEmpty() => _size == 0;

        public void Add(T e)
        {
            _root = add(_root, e);
        }

        private Node add(Node node, T e)
        {
            if (node == null)
            {
                _size++;
                return new Node(e);
            }

            if (e.CompareTo(node.Data) < 0)
            {
                node.Left = add(node.Left, e);
            }
            else if (e.CompareTo(node.Data) > 0)
            {
                node.Right = add(node.Right, e);
            }

            return node;
        }

        private bool contains(Node node, T e)
        {
            if (node == null)
            {
                return false;
            }

            if (e.CompareTo(node.Data) == 0)
            {
                return true;
            }
            else if (e.CompareTo(node.Data) < 0)
            {
                return contains(node.Left, e);
            }
            else
            {
                return contains(node.Right, e);
            }
        }

        //是否包含节点e
        public bool contains(T e)
        {
            return contains(_root, e);
        }

        //二分搜索树的前序遍历（递归）
        private void preOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);
            preOrder(node.Left);
            preOrder(node.Right);
        }

        //二分搜索树的前序遍历（递归）
        public void preOrder()
        {
            preOrder(_root);
        }

        /// <summary>
        /// 非递归 前序遍历  1.访问根节点2.前序遍历左子树 3.前序遍历右子树 
        /// </summary>
        public void preOrderNR()
        {
            Stack<Node> stack = new Stack<Node>(); //记录下一个要访问哪个节点
            stack.Push(_root);

            while (stack.Count != 0)
            {
                Node cur = stack.Pop();
                Console.WriteLine(cur.Data);
                //TODO:1.访问左子树 2.访问右子树
                if (cur.Right != null)
                {
                    stack.Push(cur.Right);
                }

                if (cur.Left != null)
                {
                    stack.Push(cur.Left);
                }
            }
        }

        public void levelOrder()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(_root);
            while (q.Count != 0)
            {
                Node cur = q.Dequeue();
                Console.WriteLine(cur.Data);

                if (cur.Left != null)
                {
                    q.Enqueue(cur.Left);
                }

                if (cur.Right != null)
                {
                    q.Enqueue(cur.Right);
                }
            }
        }

        /// <summary>
        /// 中序遍历(排序后的结果)-》从小到大
        /// </summary>
        public void inOrder()
        {
            inOrder(_root);
        }

        private void inOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            inOrder(node.Left);
            Console.WriteLine(node.Data);
            inOrder(node.Right);
        }

        public void postOrder()
        {
            postOrder(_root);
        }

        private void postOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            postOrder(node.Left); //3
            postOrder(node.Right); //6

            Console.WriteLine(node.Data);
        }

        public override string ToString()
        {
            //前序遍历
            StringBuilder res = new StringBuilder();
            generateBSTString(_root, 0, res);
            return res.ToString();
        }

        private void generateBSTString(Node node, int i, StringBuilder res)
        {
            if (node == null)
            {
                res.Append(generateDepthString(i) + "null\n");
                return;
            }

            res.Append(generateDepthString(i) + node.Data + "\n");
            generateBSTString(node.Left, i + 1, res);
            generateBSTString(node.Right, i + 1, res);
        }

        private string generateDepthString(int i)
        {
            StringBuilder res = new StringBuilder();
            for (int j = 0; j < i; j++)
            {
                res.Append("--");
            }

            return res.ToString();
        }


        public T minimum()
        {
            if (_size == 0)
            {
                throw new Exception("tree is empty");
            }

            return minimum(_root).Data;
        }

        private Node minimum(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return minimum(node.Left);
        }


        public T maxmum()
        {
            if (_size == 0)
            {
                throw new Exception("tree is empty");
            }

            return maxmum(_root).Data;
        }

        private Node maxmum(Node node)
        {
            if (node.Right == null)
            {
                return node;
            }

            return maxmum(node.Right);
        }

        public T removeMin()
        {
            T ret = minimum();
            _root = removeMin(_root);
            return ret;
        }

        private Node removeMin(Node node)
        {
            if (node.Left == null)//到了最左边的值
            {
                Node rightNode = node.Right;
                node.Right = null;
                _size--;
                return rightNode;
            }

            node.Left = removeMin(node.Left);
            return node;
        }

        public T removeMax()
        {
            T ret = maxmum();
            _root = removeMax(_root);
            return ret;
        }

        private Node removeMax(Node node)
        {
            if (node.Right==null)
            {
                Node leftNode = node.Left;
                node.Left = null;
                _size--;
                return leftNode;
            }

            node.Right = removeMax(node.Right);
            return node;
        }

        public void remove(T e)
        {
            _root = remove(_root, e);
        }

        private Node remove(Node node, T e)
        {
            if (node==null)
            {
                return null;
            }

            if (e.CompareTo(node.Data)<0)
            {
                node.Left = remove(node.Left, e);
                return node;
            }            
            else if (e.CompareTo(node.Data) > 0)
            {
                node.Right = remove(node.Right, e);
                return node;
            }
            else
            {
                if (node.Left==null)
                {
                    Node rightNode = node.Right;
                    node.Right = null;
                    _size--;
                    return rightNode;
                }

                if (node.Right==null)
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



        /// <summary>
        /// 非递归插入
        /// TODO: 1.获取插入的父节点    2.在该父节点下进行插入操作
        /// </summary>
        /// <param name="e"></param>
        public void NonRecursiveAdd(T e)
        {
            if (_root == null) //树为空树，插入根节点
            {
                _root = new Node(e);
            }
            else
            {
                Node current = _root;
                Node parent = null;
                //查找要插入的节点的父节点

                //1  5  10  8  2
                while (current != null)
                {
                    parent = current;
                    //  要插入的元素小于当前节点，则要插入的位置在当前节点的左子树
                    if (e.CompareTo(current.Data) < 0)
                    {
                        current = current.Left;
                    }
                    //  要插入的元素大于当前节点，则要插入的位置在当前节点的右子树
                    else if (e.CompareTo(current.Data) > 0)
                    {
                        current = current.Right;
                    }
                    //  要插入的元素等于当前节点的元素值，不插入
                    else
                    {
                        return;
                    }
                }

                if (e.CompareTo(parent.Data) < 0)
                {
                    parent.Left = new Node(e);
                }
                else if (e.CompareTo(parent.Data) > 0)
                {
                    parent.Right = new Node(e);
                }
            }

            _size++;
        }

        // public void Add(T e)
        // {
        //     if (_root == null)
        //     {
        //         _root = new Node(e);
        //         _size++;
        //     }
        //     else
        //     {
        //         add(_root, e);
        //     }
        // }

        // private void add(Node node, T e)
        // {
        //     if (e.CompareTo(node.Data) == 0)
        //     {
        //         return;
        //     }
        //     //添加的节点值小于当前根节点值  && 根节点的左孩子==null
        //     else if (e.CompareTo(node.Data) < 0 && node.Left == null)
        //     {
        //         node.Left = new Node(e);
        //         _size++;
        //         return;
        //     }
        //     else if (e.CompareTo(node.Data) > 0 && node.Right == null)
        //     {
        //         node.Right = new Node(e);
        //         _size++;
        //         return;
        //     }
        //
        //     //开始递归
        //     if (e.CompareTo(node.Data) < 0)
        //     {
        //         add(node.Left, e);
        //     }
        //     else //>0
        //     {
        //         add(node.Right, e);
        //     }
        // }
    }
}