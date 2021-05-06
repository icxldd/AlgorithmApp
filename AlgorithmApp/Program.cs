using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructure.Arrays;
using DataStructure.Heaps;
using DataStructure.LinkedLists;
using DataStructure.Queues;
using DataStructure.Stacks;
using DataStructure.Trees;
namespace AlgorithmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // testIntArray();
            // testStringStack();
            // testCommonQueue();
            // testSinglyLinkedList();
            // testDoublyLinkedList();
            // testSinglyLoopLinkedList();
            // BstTest();
            // maxHeapTest();

            testQueuesLeastNumbers();

        }

        private static void testQueuesLeastNumbers()
        {
            int[] arrs = new int[] { 99,97,96,95,94,93,80};

            foreach (var item in getLeastNumbers(arrs, 3))
            {
                Console.WriteLine(item);    
            }
            // getLeastNumbers();
        }

        private static int[] getLeastNumbers(int[] arr,int k)
        {
            PriorityQueue<int> queues = new PriorityQueue<int>();
            for (int i = 0; i < k; i++)
            {
                queues.enqueue(arr[i]);
            }

            for (int i = k; i < arr.Length; i++)
            {
                if (!queues.isEmpty()&&arr[i]<queues.getFront())
                {
                    queues.dequeue();
                    queues.enqueue(arr[i]);
                }
            }

            int[] res = new int[k];
            for (int i = 0; i < k; i++)
            {
                res[i] = queues.dequeue();
            }
            return res;
        }

        private static void maxHeapTest()
        {
            int n = 300;
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            Random random = new Random();
            for (int i = 0; i <n; i++)
            {
                maxHeap.add(random.Next(int.MaxValue));
            }

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = maxHeap.extractMax();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static void BstTest()
        {
            System.Collections.Generic.Queue<Context> q = new System.Collections.Generic.Queue<Context>();
            BstBinaryTree<Context> bst = new BstBinaryTree<Context>();
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                bst.Add(new Context(random.Next(10000), random.Next(10000) + "tag"));
            }

            bst.Add(new Context(555, "icxl add"));
            bst.Add(new Context(687, "icxl add"));

            // bst.remove(new Context(555, "icxl add"));

            Console.WriteLine("-----------------------------------------");

            var b = bst.contains(new Context(555, "icxl add"));
            int count = bst.GetSize();
            for (int i = 0; i < count; i++)
            {
                q.Enqueue(bst.removeMax());
            }

            int qCount = q.Count;
            for (int i = 0; i < qCount; i++)
            {
                var obj = q.Dequeue();
                Console.WriteLine(obj.Value);
            }


            Console.WriteLine("555是否存在：" + b);


            // BstBinaryTree<int> bst = new BstBinaryTree<int>();
            // // int[] number = {5,3,9,8,4,2,10};
            // int[] number = {5,3,6,2,4,8};
            // for (int i = 0; i < number.Length; i++)
            // {
            //     bst.Add(number[i]);
            // }
            //
            //
            // bst.levelOrder();
            // bst.preOrder();
            // Console.WriteLine("");
            // bst.preOrderNR();
            // Console.WriteLine("");
            // Console.WriteLine(bst);
            // Console.WriteLine("");
            // bst.inOrder();
            // Console.WriteLine("");
            // bst.postOrder();
        }

        private static void testSinglyLoopLinkedList()
        {
            SinglyLoopLinkedList<int> dlink = new SinglyLoopLinkedList<int>();
            dlink.Insert(333, 0);
            dlink.Append(333666);
            dlink.Insert(123333, 2);
            dlink.Append(333666);
            dlink.Insert(258, 1);
            // for (int i = 0; i < 20; i++)
            // {
            //     dlink.Insert(i,i);
            // }
            dlink.ShowAll();
        }

        private static void testDoublyLinkedList()
        {
            DoublyLinkedList<int> dlink = new DoublyLinkedList<int>(); // 创建双向链表
            dlink.AppendEnd(100);
            dlink.Insert(0, 10);
            dlink.ShowAll();
            dlink.Insert(0, 30);
            dlink.ShowAll();
            dlink.Insert(0, 40);
            dlink.AppendEnd(100);
            dlink.ShowAll();
            dlink.Insert(1, 20);
            dlink.ShowAll();
            dlink.DelFirst();
            dlink.DelLast();
            dlink.Del(2);
            dlink.ShowAll();
            Console.ReadKey();
        }

        private static void testSinglyLinkedList()
        {
            var _singlylinkedlist = new SinglyLinkedList<int>();
            _singlylinkedlist.AddTheEnd(666);
            for (int i = 0; i < 100; i++)
            {
                _singlylinkedlist.Insert(i, i);
            }

            Console.WriteLine(_singlylinkedlist.ToString());
            _singlylinkedlist.Insert(1314, 0);
            _singlylinkedlist.Insert(3344, 1);
            _singlylinkedlist.Insert(6666, 5);
            _singlylinkedlist.AddTheEnd(888);
            Console.WriteLine(_singlylinkedlist.ToString());
            _singlylinkedlist.Remove(0);
            _singlylinkedlist.Remove(3);
            Console.WriteLine(_singlylinkedlist.ToString());
            _singlylinkedlist.Update(111111, 0);
            _singlylinkedlist.Update(111111, _singlylinkedlist.Count - 1);
            Console.WriteLine(_singlylinkedlist.ToString());
            foreach (var item in _singlylinkedlist)
            {
                Console.WriteLine(item);
            }
        }

        private static void testCommonQueue()
        {
            var queues = new CommonQueue<string>();
            for (int i = 1; i <= 100; i++)
            {
                queues.Enqueue(i.ToString());
            }

            Console.WriteLine(queues.ToString());
            Console.WriteLine(queues.Dequeue());
            Console.WriteLine(queues.Dequeue());
            Console.WriteLine(queues.Dequeue());
            Console.WriteLine(queues.ToString());
        }

        private static void testStringStack()
        {
            StringStack stacks = new StringStack();
            for (int i = 0; i < 100; i++)
            {
                stacks.Push(i.ToString());
            }

            Console.WriteLine(stacks.ToString());
            Console.WriteLine(stacks.Pop());
            Console.WriteLine(stacks.Pop());
            stacks.Push("i.ToString()");
            Console.WriteLine(stacks.ToString());
            for (int i = 0; i < 100; i++)
            {
                stacks.Push(i.ToString());
            }

            Console.WriteLine(stacks.ToString());
        }

        private static void testIntArray()
        {
            IntArray arrays = new IntArray(10);
            arrays.Add(1);
            arrays.Add(13);
            arrays.Add(53);
            arrays.Add(33);

            Console.WriteLine(arrays.ToString());
            arrays[0] = 11;
            Console.WriteLine(arrays.ToString());
            arrays.Update(3, 55);
            Console.WriteLine(arrays.ToString());
            arrays.Remove(0);
            Console.WriteLine(arrays.ToString());
            arrays.Remove(1);
            Console.WriteLine(arrays.ToString());
        }
    }
}