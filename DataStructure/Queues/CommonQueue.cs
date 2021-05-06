using System.Collections.Generic;

namespace DataStructure.Queues
{
    public interface ICommonQueue<T>
    {
        public void Enqueue(T value);

        public T Dequeue();

        public int Count { get; }

    }

    public class CommonQueue<T>:ICommonQueue<T>
    {
        /// <summary>
        /// item
        /// </summary>
        private T[] _item { get; set; }
        /// <summary>
        /// 最大容量(default：10)
        /// </summary>
        private int _maxCapacity { get; set; } = 10;
        /// <summary>
        /// 当前添加 ，节点索引
        /// </summary>
        private int _currentAddIndex { get; set; } = 0;
        private void InitData(int capacity)
        {
            _item = new T[capacity];
            _currentAddIndex = 0;
            _maxCapacity = capacity;
        }

        /// <summary>
        /// 是否需要扩容
        /// </summary>
        /// <returns></returns>
        private bool isCanExpansion()
        {
            if (_currentAddIndex == _maxCapacity - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 扩容
        /// </summary>
        private void expansionStack()
        {
            _maxCapacity = _maxCapacity * 2;
            var itemArrays = new T[_maxCapacity];
            for (int i = 0; i < _currentAddIndex; i++)
            {
                itemArrays[i] = _item[i];
            }
            _item = itemArrays;
        }
        
        private void reSortIndex(int index)
        {
            for (int i = index; i < _currentAddIndex; i++)
            {
                _item[i] = _item[i + 1];
            }
        }
        public CommonQueue()
        {
            InitData(_maxCapacity);
        }

        public void Enqueue(T value)
        {
            if (isCanExpansion())
            {
                expansionStack();
            }
            _item[_currentAddIndex] = value;
            _currentAddIndex++;
        }

        public T Dequeue()
        {
            T val = _item[0];
            reSortIndex(0);
            return val;
        }

        public override string ToString()
        {
            string str ="当前数据："+ string.Join(",", _item);
            return str;
        }
        public int Count => _currentAddIndex;
    }
}