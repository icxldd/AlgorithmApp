using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DataStructure.LinkedLists
{
    public class SinglyNode<T>
    {
        public T Data { get; set; }
        public SinglyNode<T> NextData { get; set; }

        public SinglyNode(T data)
        {
            Data = data;
        }

        public SinglyNode()
        {
        }
    }


    public class SinglyLinkedList<T>:IEnumerable<T>
    {
        /// <summary>
        /// 头节点
        /// </summary>
        private SinglyNode<T> _head;

        /// <summary>
        /// 当前链表数量
        /// </summary>
        private int _count;

        public SinglyLinkedList()
        {
            _count = 0;
        }

        public void AddTheEnd(T data)
        {
            if (_head == null)
            {
                _head = new SinglyNode<T>(data);
                goto end;
            }

            GetOrNull(_count-1).NextData = new SinglyNode<T>(data);
            end:
            _count += 1;
        }

        public void Insert(T data, int index)
        {
            if (index == 0 && _head == null)
            {
                _head = new SinglyNode<T>(data);
                goto end;
            }

            var topNode = GetOrNull(index);
            if (topNode == null)
            {
                GetOrNull(index - 1).NextData = new SinglyNode<T>(data);
                goto end;
            }

            //head 把head赋值，head的next赋值原node
            if (index == 0)
            {
                var itemHead = _head;
                var node = new SinglyNode<T>(data);
                node.NextData = itemHead;
                _head = node;
            }
            //不是Head 把index-1的next赋值value node ，value node next赋值原 node
            else
            {
                var topNode_ = GetOrNull(index - 1);
                var itemNode_ = topNode_.NextData;
                topNode_.NextData = new SinglyNode<T>(data);
                topNode_.NextData.NextData = itemNode_;
            }

            end:
            _count += 1;
        }

        public void Remove(int index)
        {
            if (index == 0)
            {
                _head = _head.NextData;
            }
            else
            {
                SinglyNode<T> topSinglyNode = GetOrNull(index - 1);
                SinglyNode<T> endSinglyNode = GetOrNull(index + 1);
                topSinglyNode.NextData = endSinglyNode;
            }
            
            
            end:
            _count -= 1;
        }

        public void Update(T data, int index)
        {
            this[index] = data;
        }

        private SinglyNode<T> GetOrNull(int index)
        {
            var itemNode = _head;
            for (var i = 0; i < index; i++)
            {
                if (itemNode.NextData == null)
                {
                    return null;
                }

                itemNode = itemNode.NextData;
            }

            return itemNode;
        }

        /// <summary>
        /// 根据索引获取链表值
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public T this[int index]
        {
            get
            {
                var itemNode = _head;
                for (var i = 0; i < index; i++)
                {
                    itemNode = itemNode.NextData ?? throw new ArgumentNullException(nameof(index), "index is error");
                }

                return itemNode.Data;
            }
            set
            {
                var itemNode = _head;
                for (var i = 0; i < index; i++)
                {
                    itemNode = itemNode.NextData ??
                               throw new ArgumentNullException(nameof(index), "this index is null");
                }

                itemNode.Data = value;
            }
        }

        public int Count => _count;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return this[i];
            }
        }
       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _count; i++)
            {
                str += this[i].ToString() + ",";
            }

            return str;
        }

    }
}