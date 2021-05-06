using System;
using DataStructure.Heaps;

namespace DataStructure.Sorts
{
    public class HeapSort
    {
        private HeapSort()
        {
        }

        public static void sort<T>(T[] data) where T : IComparable<T>
        {
            MaxHeap<T> maxHeap = new MaxHeap<T>();
            for (int i = 0; i < data.Length; i++)
            {
                maxHeap.add(data[i]);
            }
            for (int i = data.Length - 1; i >= 0; i--)
            {
                data[i] = maxHeap.extractMax();
            }
        }



        public static void sort2<T>(T[] data) where T : IComparable<T>
        {
            MaxHeap<T> maxHeap = new MaxHeap<T>(data);
            
            
            
        }
    }
}