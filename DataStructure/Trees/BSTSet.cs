using System;
using DataStructure.DataStructure;

namespace DataStructure.Trees
{
    public class BSTSet<T> : Set<T> where T : IComparable<T>
    {
        private BstBinaryTree<T> bst;

        public BSTSet()
        {
            bst = new BstBinaryTree<T>();
        }

        public void add(T t)
        {
            add(t);
        }

        public void remove(T t)
        {
            bst.remove(t);
        }

        public bool contains(T t)
        {
            return bst.contains(t);
        }

        public int getSize()
        {
            return bst.GetSize();
        }

        public bool isEmpty()
        {
            return bst.GetSize() == 0;
        }
    }
}