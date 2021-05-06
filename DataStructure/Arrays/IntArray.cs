using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Arrays
{
    /// <summary>
    ///  int数组
    /// </summary>
    public class IntArray : IIntArray
    {
        public IntArray(int maxCapacity)
        {
            reLoadData(maxCapacity);
        }

        private int[] _array { get; set; }

        /// <summary>
        /// 最大容量
        /// </summary>
        private int _maxCapacity { get; set; }

        /// <summary>
        /// 当前索引
        /// </summary>
        private int _currentIndex { get; set; }

        public int this[int index]
        {
            get => this._array[index];
            set => this._array[index] = value;
        }

        public void Add(int value)
        {
            _array[_currentIndex] = value;
            _currentIndex++;
        }

        /// <summary>
        /// 删除节点，重新调整索引
        /// </summary>
        /// <param name="index"></param>
        private void reSortIndex(int index)
        {
            for (int i = index; i < _currentIndex; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        public override string ToString()
        {
            string str ="当前数组数据："+ string.Join(",", _array);
            return str;
        }

        private void reLoadData(int maxCapacity)
        {
            _array = new int[maxCapacity];
            _maxCapacity = maxCapacity;
            _currentIndex = 0;
        }

        public void Remove(int index)
        {
            reSortIndex(index);
        }

        public void RemoveAll()
        {
            reLoadData(5);
        }

        public int Get(int index)
        {
            return _array[index];
        }

        public void Update(int index, int value)
        {
            _array[index] = value;
        }

        public int Count => _currentIndex;
    }
}