using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class LinkedList
    {
        private Node First { get; set; }
        private Node Last { get; set; }
        public int Size { get; private set; }

        public void AddFirst(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
                First = Last = node;
            else
            {
                node.Next = First;
                First = node;
            }

            Size++;
        }

        public void AddLast(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
                First = Last = node;
            else
            {
                Last.Next = node;
                Last = node;
            }

            Size++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The LinkedList is empty.");

            if (First == Last)
            {
                First = Last = null;
            }
            else
            {
                var second = First.Next;
                First.Next = null;
                First = second;
            }

            Size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The LinkedList is empty.");

            if (First == Last)
            {
                First = Last = null;
            }
            else
            {
                var previous = GetPrevious(Last);
                previous.Next = null;
                Last = previous;
            }

            Size--;
        }

        public int IndexOf(int value)
        {
            var index = 0;
            var current = First;

            while(current != null)
            {
                if (current.Value == value)
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        public void Reverse()
        {
            if (IsEmpty())
                return;

            var current = First;
            var next = First.Next;

            while (next != null)
            {
                var temp = next.Next;
                next.Next = current;

                current = next;
                next = temp;
            }

            Last = First;
            Last.Next = null;

            First = current;
        }

        public int GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
                throw new InvalidOperationException("The LinkedList Is Empty.");

            if (k < 1 || k > Size)
                throw new InvalidOperationException("Invalid k argument.");

            var target = First;
            var pointer = First;

            for (var i = 0; i < k - 1; i++)
                pointer = pointer.Next;

            while (pointer.Next != null)
            {
                pointer = pointer.Next;
                target = target.Next;
            }

            return target.Value;
        }

        public int[] ToArray()
        {
            int[] array = new int[Size];

            var current = First;
            var index = 0;
            while(current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public static LinkedList CreateLoop()
        {
            var list = new LinkedList();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            var node = list.Last;

            list.AddLast(40);
            list.AddLast(50);
            list.AddLast(60);

            list.Last.Next = node;

            return list;
        }

        public bool HasLoop()
        {
            var slow = First;
            var fast = First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    return true;
            }

            return false;
        }

        public void PrintMiddle()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The LinkedList Is Empty.");

            var target = First;
            var pointer = First;

            while (pointer != Last && pointer.Next != Last)
            {
                pointer = pointer.Next.Next;
                target = target.Next;
            }

            if (pointer == Last)
                Console.WriteLine(target.Value);
            else
                Console.WriteLine(target.Value + ", " + target.Next.Value);
        }

        public void Print()
        {
            var current = First;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        private Node GetPrevious(Node node)
        {
            var current = First;

            while (current != null)
            {
                if (current.Next == node)
                    return current;

                current = current.Next;
            }

            return null;
        }

        private bool IsEmpty()
        {
            return First == null;
        }

        private class Node
        {
            internal int Value { get; set; }
            internal Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }
    }
}
