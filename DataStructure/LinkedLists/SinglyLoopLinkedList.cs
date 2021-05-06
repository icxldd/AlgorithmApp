using System;

namespace DataStructure.LinkedLists
{
    /// <summary>
    /// 单向循环列表_数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLoopNode<T>
    {
        public T Data { get; set; }
        public SinglyLoopNode<T> NextNode { get; set; }

        public SinglyLoopNode()
        {
        }

        public SinglyLoopNode(T data)
        {
            Data = data;
        }

        public SinglyLoopNode(T data, SinglyLoopNode<T> nextNode)
        {
            Data = data;
            NextNode = nextNode;
        }
    }


    public interface ISinglyLoopLinkedList<T>
    {
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 删除所有
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 末尾添加节点
        /// </summary>
        /// <param name="item"></param>
        void Append(T item);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        void Insert(T item, int i);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        void Update(T item, int i);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="i"></param>
        void Delete(int i);

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T GetElem(int i);
    }

    public class SinglyLoopLinkedList<T> : ISinglyLoopLinkedList<T>
    {
        private SinglyLoopNode<T> _head;
        private int _count;

        public SinglyLoopLinkedList()
        {
            _head = null;
            _count = 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public void ShowAll()
        {
            Console.WriteLine("******************* 链表数据如下 *******************");
            for (int i = 0; i < _count; i++)
                Console.WriteLine("(" + i + ")=" + GetElem(i));
            Console.WriteLine("******************* 链表数据展示完毕 *******************\n");
        }
        private SinglyLoopNode<T> GetHeadNode() => GetNode(0);
        private SinglyLoopNode<T> GetLastNode() => GetNode(_count-1);


        /// <summary>
        /// 添加node自增
        /// </summary>
        private void increasingCount() => _count++;
        
        /// <summary>
        /// 删除Node 自减
        /// </summary>
        private void decreaseCount() => _count--;
        
        private SinglyLoopNode<T> GetNode(int index)
        {
            var itemNode = _head;
            for (var i = 0; i < index; i++)
            {
                if (itemNode.NextNode == null)
                {
                    return null;
                }
                itemNode = itemNode.NextNode;
            }
            return itemNode;
        }


        public int GetCount() => _count;
        

       
        public bool IsEmpty() => _count < 1;
        

        public void Append(T item)
        {
           var node =  new SinglyLoopNode<T>(item,_head);
           if (IsEmpty())
           {
               _head = node;
           }
           else
           {
               GetLastNode().NextNode = node;
           }

           increasingCount();
        }

        public void Insert(T data, int index)
        {
            if (index == 0 && _head == null)
            {
                Append(data);
                return;
            }

            var topNode = GetNode(index);
            if (topNode == null)
            {
               throw new ArgumentOutOfRangeException(nameof(index),"Index out range");
            }

            if (index == 0)
            {
                var itemHead = _head;
                var node = new SinglyLoopNode<T>(data);
                node.NextNode = itemHead;
                _head = node;
                GetLastNode().NextNode.NextNode = _head;
            }
            else
            {
                var topNode_ = GetNode(index - 1);
                var itemNode_ = topNode_.NextNode;
                topNode_.NextNode = new SinglyLoopNode<T>(data);
                topNode_.NextNode.NextNode = itemNode_;
            }

            _count += 1;
        }
        
        public void RemoveAll()
        {
            
        }

        public void Update(T item, int i)
        {
            GetNode(i).Data = item;
        }

        public void Delete(int i)
        {
            
            
        }

        public T GetElem(int i) => GetNode(i).Data;
        
    }
}