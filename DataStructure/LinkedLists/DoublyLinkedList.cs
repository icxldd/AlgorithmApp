using System;

namespace DataStructure.LinkedLists
{
    public class DoublyNode<T>
    {
        public T Data { get; set; }

        public DoublyNode<T> Next { get; set; }

        public DoublyNode<T> Prev { get; set; }

        public DoublyNode(T data, DoublyNode<T> next, DoublyNode<T> prev)
        {
            Data = data;
            Next = next;
            Prev = prev;
        }
    }


    public class DoublyLinkedList<T>
    {
        private DoublyNode<T> _linkHead;
        private int _count;

        public DoublyLinkedList()
        {
            _linkHead = new DoublyNode<T>(default(T), null, null); //双向链表 表头为空
            _linkHead.Prev = _linkHead;
            _linkHead.Next = _linkHead;
            _count = 0;
        }
        private DoublyNode<T> GetNode(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("索引溢出或者链表为空");
            }

            var itemNode = _linkHead;
            for (var i = 0; i < index; i++)
            {
                itemNode = itemNode.Next;
            }

            return itemNode;
        }


        public int GetCount() => _count;

        public bool IsEmpty() => _count == 0;

        public T Get(int index) => GetNode(index).Data;

        public T GetFristNode() => GetNode(0).Data;

        public T GetLastNode() => GetNode(_count - 1).Data;


        public void AppendEnd(T data)
        {
            if (_count == 0)
            {
                _linkHead = new DoublyNode<T>(data, null, null);
                goto endAddCount;
            }
            else
            {
                var node = GetNode(_count - 1);
                var newNode = new DoublyNode<T>(data, _linkHead, node);
                _linkHead.Prev = newNode;
                node.Next = newNode;
                goto endAddCount;
            }

            endAddCount:
            _count++;
        }

        public void Insert(int index, T data)
        {
            if (index == 0 && _count == 0)
            {
                AppendEnd(data);
                return;
            }
            if (index == 0)
            {
                var prevNode = GetNode(_count-1);
                var nextNode = GetNode(index);
                var newNode = new DoublyNode<T>(data, nextNode, prevNode);
                prevNode.Next = newNode;
                nextNode.Prev = newNode;
                goto endAddCount;
            }
            else
            {
                //末尾
                if (index == _count - 1)
                {
                    var prevNode = GetNode(index);
                    var nextNode =_linkHead;
                    var newNode = new DoublyNode<T>(data, nextNode, prevNode);
                    prevNode.Next = newNode;
                    _linkHead.Prev = newNode;
                    goto endAddCount;
                }
                else
                {
                    var prevNode = GetNode(index-1);
                    var nextNode = GetNode(index);
                    var newNode = new DoublyNode<T>(data, nextNode, prevNode);
                    prevNode.Next = newNode;
                    nextNode.Prev = newNode;
                    goto endAddCount;
                }
            }
            endAddCount:
            _count++;
        }
        
        public void Del(int index)
        {
            DoublyNode<T> inode = GetNode(index);
            inode.Prev.Next = inode.Next;
            inode.Next.Prev = inode.Prev;
            if (index==0)
            {
                _linkHead = inode.Next;
            }
          
            _count--;
        }
        
        public void DelFirst() => Del(0);
        public void DelLast() => Del(_count - 1); 
        
        public void ShowAll()
        {
            Console.WriteLine("******************* 链表数据如下 *******************");
            for (int i = 0; i < _count; i++)
                Console.WriteLine("(" + i + ")=" + Get(i));
            Console.WriteLine("******************* 链表数据展示完毕 *******************\n");
        }
    }
}