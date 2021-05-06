using System.Collections.Generic;

namespace DataStructure.Stacks
{
    public interface IStringStack
    {
        public void Push(string value);

        public string Pop();

        public int Count { get; }
    }

    public class StringStack : IStringStack
    {
        /// <summary>
        /// item
        /// </summary>
        private string[] _item { get; set; }

        /// <summary>
        /// 最大容量(default：10)
        /// </summary>
        private int _maxCapacity { get; set; } = 10;

        /// <summary>
        /// 当前节点索引
        /// </summary>
        private int _currentAddIndex { get; set; } = 0;

        private void InitData(int capacity)
        {
            _item = new string[capacity];
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
            var itemArrays = new string[_maxCapacity];
            for (int i = 0; i < _currentAddIndex; i++)
            {
                itemArrays[i] = _item[i];
            }

            _item = itemArrays;
        }

        private void PopAfter()
        {
            _currentAddIndex = _currentAddIndex - 1;
            _item[_currentAddIndex] = null;
        }

        public StringStack()
        {
            InitData(_maxCapacity);
        }


        public void Push(string value)
        {
            if (isCanExpansion())
            {
                expansionStack();
            }

            _item[_currentAddIndex] = value;
            _currentAddIndex++;
        }

        public string Pop()
        {
            string value = _item[_currentAddIndex - 1];
            PopAfter();
            return value;
        }

        public override string ToString()
        {
            string str ="当前数据："+ string.Join(",", _item);
            return str;
        }

        public int Count => _currentAddIndex;
    }

}