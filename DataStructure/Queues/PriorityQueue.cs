using System;
using DataStructure.Heaps;

namespace DataStructure.Queues
{
    /// <summary>
    /// 最大堆  优先队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>:Queue<T> where T:IComparable<T>
    {
        private MaxHeap<T> _maxHeap;

        public PriorityQueue()
        {
            _maxHeap = new MaxHeap<T>();
        }

        public int getSize()
        {
            return _maxHeap.size();
        }

        public bool isEmpty()
        {
            return _maxHeap.isEmpty();
        }

        public T getFront()
        {
            return _maxHeap.findMax();
        }

        public void enqueue(T e)
        {
            _maxHeap.add(e);
        }

        public T dequeue()
        {
            return _maxHeap.extractMax();
        }
    }
}