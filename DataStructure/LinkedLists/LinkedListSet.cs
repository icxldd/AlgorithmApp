using System.Collections.Generic;
using DataStructure.DataStructure;

namespace DataStructure.LinkedLists
{
    public class LinkedListSet<T> : LinkedList<T>, Set<T>
    {
        public void add(T t)
        {
            if (!contains(t))
            {
                AddFirst(t);
            }
        }

        public void remove(T t)
        {
            Remove(t);
        }

        public bool contains(T t)
        {
            return this.Contains(t);
        }

        public int getSize()
        {
            return Count;
        }

        public bool isEmpty()
        {
            return Count == 0;
        }
    }
}