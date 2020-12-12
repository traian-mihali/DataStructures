using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class ArrayQueue
    {
        private int[] items;
        private int count;
        private int front;
        private int rear;

        public ArrayQueue(int capacity)
        {
            items = new int[capacity];
        }
        public void Enqueue(int item)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full.");

            items[rear] = item;
            rear = (rear + 1) % items.Length;
            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            int item = items[front];
            items[front] = 0;
            front = (front + 1) % items.Length;
            count--;
            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return items[front];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == items.Length;
        }

        public override string ToString()
        {
            string output = "";
            foreach (var item in items)
                output += item + " ";

            return output;
        }
    }
}
