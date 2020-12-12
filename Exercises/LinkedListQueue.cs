using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    public class LinkedListQueue
    {
        private Node First;
        private Node Last;
        private int count;

        public void Enqueue(int value)
        {
            Node node = new Node(value);

            if(IsEmpty())
                First = Last = node;
            else
            {
                Last.Next = node;
                Last = node;
            }

            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            int value = First.Value;

            if (First == Last)
                First = Last = null;
            else
                First = First.Next;

            count--;

            return value;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return First.Value;
        }

        public int Size()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return First == null;
        }


        private class Node
        {
            internal int Value { get; set; }
            internal Node Next { get; set; }

            internal Node(int value)
            {
                Value = value;
            }
        }
    }

}
