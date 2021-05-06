using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Heaps
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private List<T> _data;

        public MaxHeap(int capacity)
        {
            _data = new List<T>(capacity);
        }

        /// <summary>
        /// Heapify 
        /// </summary>
        /// <param name="arr"></param>
        public MaxHeap(T[] arr)
        {
            _data = new List<T>(arr);
            
            for (int i = parent(_data.Count - 1); i >= 0; i--)
            {
                siftDown(i);
            }
        }

        public MaxHeap()
        {
            _data = new List<T>();
        }

        public int size()
        {
            return _data.Count;
        }

        public bool isEmpty()
        {
            return _data.Count == 0;
        }

        private int parent(int index)
        {
            if (index == 0)
            {
                throw new Exception("index-0 doesn't have parent.");
            }

            return (index - 1) / 2;
        }

        private int leftChild(int index)
        {
            return index * 2 + 1;
        }

        private int rightChild(int index)
        {
            return index * 2 + 2;
        }


        private void swap(int i, int j)
        {
            if (i < 0 || i >= _data.Count || j < 0 || j >= _data.Count)
            {
                throw new Exception("index error");
            }

            T item1 = _data[i];
            T item2 = _data[j];
            _data[i] = item2;
            _data[j] = item1;
        }

        public void add(T e)
        {
            _data.Add(e);
            siftUp(_data.Count - 1);
        }

        public T findMax()
        {
            if (_data.Count == 0)
            {
                throw new Exception("arrar index is 0");
            }

            return _data[0];
        }

        /// <summary>
        /// 取出最大值
        /// </summary>
        /// <returns></returns>
        public T extractMax()
        {
            T ret = findMax();
            swap(0, _data.Count - 1);
            _data.RemoveAt(_data.Count - 1);
            siftDown(0);
            return ret;
        }

        public T replace(T e)
        {
            T ret = findMax();
            _data[0] = e;
            siftDown(0);
            return ret;
        }

        private void siftUp(int k)
        {
            while (k > 0 && _data[parent(k)].CompareTo(_data[k]) < 0)
            {
                swap(k, parent(k));
                k = parent(k);
            }
        }

        private void siftDown(int k)
        {
            while (leftChild(k) < _data.Count)
            {
                int j = leftChild(k);
                if (j + 1 < _data.Count && _data[j + 1].CompareTo(_data[j]) > 0)
                {
                    j = rightChild(k);
                }

                if (_data[k].CompareTo(_data[j]) >= 0)
                {
                    break;
                }

                swap(k, j);
                k = j;
            }
        }
    }
}