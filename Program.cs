using DataStructures.Exercises;
using DataStructures.Helpers;
using DataStructures.LinearStructures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestArray();
            //TestLinkedList();
            //TestStringHelper();

            //TestStack();
            //TestMinStack();
            //TestTwoStacks();

            //TestReverseQueueMethod();
            //TestArrayQueue();
            //TestQueueWithTwoStacks();
            //TestPriorityQueue();

            Console.ReadLine();
        }

        static void TestArray()
        {
            var array = new LinearStructures.Array(3);

            array.Insert(1);
            array.Insert(2);
            array.Insert(3);
            array.Print();


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REMOVE FROM INDEX 0");
            array.RemoveAt(0);
            array.Print();

            Console.WriteLine("INSERT 1 AT INDEX 0");
            array.InsertAt(0, 1);
            array.Print();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REVERSED ARRAY");
            var reversed = array.Reverse();
            foreach (var item in reversed)
                Console.WriteLine(item);


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("INTERSECTION WITH [1, 4]");
            var other = new LinearStructures.Array(2);
            other.Insert(1);
            other.Insert(4);
            var intersection = array.Intersect(other);
            intersection.Print();
        }

        static void TestLinkedList()
        {
            var list = new LinkedList();

            //list.AddFirst(10);
            //list.AddFirst(20);
            //list.AddFirst(30);
            //list.Print();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);
            list.Print();

            var loopList = LinkedList.CreateLoop();
            Console.WriteLine("HAS LOOP: " + loopList.HasLoop());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("LIST MIDDLE VALUE: ");
            list.PrintMiddle();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("kth is 1: " + list.GetKthFromTheEnd(1));
            Console.WriteLine("kth is 2: " + list.GetKthFromTheEnd(2));
            Console.WriteLine("kth is 3: " + list.GetKthFromTheEnd(3));



            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST SIZE: " + list.Size);

            //Console.WriteLine(Environment.NewLine);
            //list.RemoveFirst();
            //list.Print();

            //Console.WriteLine(Environment.NewLine);
            //list.RemoveLast();
            //list.Print();


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("INDEX OF 10: " + list.IndexOf(10));
            Console.WriteLine("INDEX OF 20: " + list.IndexOf(20));
            Console.WriteLine("INDEX OF 30: " + list.IndexOf(30));
            Console.WriteLine("INDEX OF 40: " + list.IndexOf(40));


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("CONTAINS 10: " + list.Contains(10));
            Console.WriteLine("CONTAINS 20: " + list.Contains(20));
            Console.WriteLine("CONTAINS 30: " + list.Contains(30));
            Console.WriteLine("CONTAINS 40: " + list.Contains(40));

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST SIZE: " + list.Size);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST TO ARRAY: " + String.Join(", ", list.ToArray()));

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REVERSE LINKEDLIST");
            list.Reverse();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST TO ARRAY: " + String.Join(", ", list.ToArray()));
        }

        static void TestStringHelper()
        {
            //Console.WriteLine(StringHelper.Reversed("abcd"));
            //Console.WriteLine(Reversed(null));

            Console.WriteLine(StringHelper.IsBalanced("(abc)"));
            Console.WriteLine(StringHelper.IsBalanced("[abc]"));
            Console.WriteLine(StringHelper.IsBalanced("{abc}"));
            Console.WriteLine(StringHelper.IsBalanced("<abc>"));

            Console.WriteLine(StringHelper.IsBalanced("((abc)"));
            Console.WriteLine(StringHelper.IsBalanced("abc)"));
            Console.WriteLine(StringHelper.IsBalanced(")abc("));
            Console.WriteLine(StringHelper.IsBalanced("[abc}"));
            Console.WriteLine(StringHelper.IsBalanced("<abc}"));
        }

        static void TestStack()
        {
            var stack = new LinearStructures.Stack(3);

            Console.WriteLine("stack.IsEmpty() " + stack.IsEmpty());
            //Console.WriteLine("stack.Pop() " + stack.Pop());

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            //stack.Push(4);

            Console.WriteLine("stack.Pop() " + stack.Pop());
            Console.WriteLine("stack.Peek() " + stack.Peek());
            Console.WriteLine("stack.Pop() " + stack.Pop());
            Console.WriteLine("stack.Peek() " + stack.Peek());
            Console.WriteLine("stack.Pop() " + stack.Pop());
            //Console.WriteLine("stack.Peek() " + stack.Peek());
        }

        static void TestMinStack()
        {
            var minStack = new MinStack(5);

            //minStack.Pop();

            minStack.Push(5);
            minStack.Push(2);
            minStack.Push(4);
            minStack.Push(3);
            minStack.Push(1);

            Console.WriteLine(minStack.Min());
            minStack.Pop();
            Console.WriteLine(minStack.Min());

        }

        static void TestTwoStacks()
        {
            var twoStacks = new TwoStacks(5);

            twoStacks.Push1(1); 
            twoStacks.Push1(2);
            twoStacks.Push2(3);
            twoStacks.Push2(4);
            twoStacks.Push2(5);

            Console.WriteLine(twoStacks.Pop1());
            Console.WriteLine(twoStacks.Pop1());
            //Console.WriteLine(twoStacks.Pop1());

            Console.WriteLine(twoStacks.Pop2());
            Console.WriteLine(twoStacks.Pop2());
            Console.WriteLine(twoStacks.Pop2());
            //Console.WriteLine(twoStacks.Pop2());

            twoStacks.Push1(10);
            twoStacks.Push2(20);

        }

        static void TestArrayQueue()
        {
            ArrayQueue queue = new ArrayQueue(5);

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            //Console.WriteLine(queue.Dequeue());

            queue.Dequeue();
            queue.Dequeue();

            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);

            queue.Dequeue();
            queue.Enqueue(80);


            Console.WriteLine(queue);
        }

        static void TestReverseQueueMethod()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);


            var reversed = QueueReverser.Reverse(queue);

            Console.WriteLine(reversed);
        }

        static void TestQueueWithTwoStacks()
        {
            QueueWithTwoStacks queue = new QueueWithTwoStacks(3);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            //queue.Enqueue(40);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            //queue.Dequeue();
        }

        static void TestPriorityQueue()
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Add(5);
            queue.Add(3);
            queue.Add(6);
            queue.Add(1);
            queue.Add(4);

            queue.Remove();
            queue.Remove();
            //queue.Remove();
            //queue.Remove();
            //queue.Remove();

            //Console.WriteLine(queue.Remove());
            queue.Add(2);

            Console.WriteLine(queue);
        }

    }
}
