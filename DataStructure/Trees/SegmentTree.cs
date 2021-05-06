using System;

namespace DataStructure.Trees
{
    public interface Merger<T>
    {
        public T merger(T a,T b);
    }

    public class SegmentTree<T>
    {
        private T[] _tree;
        private T[] _data;

        public SegmentTree(T[] arrs)
        {
            _data.CopyTo(arrs, arrs.Length);
            _tree = new T[4 * arrs.Length];
            buildSegmentTree(0, 0, _data.Length - 1);
        }


        //在treeIndex的位置创建区间【l...r】的线段树
        private void buildSegmentTree(int treeIndex, int l, int r)
        {
            if (l == r)
            {
                _tree[treeIndex] = _data[l];
                return;
            }

            int leftTreeIndex = leftChild(treeIndex);
            int rightTreeIndex = rightChild(treeIndex);

            int mid = l+(r-l)/2;
            
            buildSegmentTree(leftTreeIndex,l,mid);
            buildSegmentTree(rightTreeIndex,mid+1,r);
            //区间node值设置
            // _tree[treeIndex] = _tree[leftTreeIndex] + _tree[rightTreeIndex];


        }

        public int getSize()
        {
            return _data.Length;
        }

        public T get(int index)
        {
            if (index < 0 || index >= _data.Length)
            {
                throw new Exception("index out error");
            }

            return _data[index];
        }

        private int leftChild(int index)
        {
            return 2 * index + 1;
        }

        private int rightChild(int index)
        {
            return 2 * index + 2;
        }
    }
}