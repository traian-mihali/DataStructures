using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    class StackWithTwoQueues
    {
        private Queue<int> queue1 = new Queue<int>();
        private Queue<int> queue2 = new Queue<int>();
        private int top;

        public void Push(int item)
        {
            queue1.Enqueue(item);
            top = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");


            while (queue1.Count > 1)
            {
                top = queue1.Dequeue();
                queue2.Enqueue(top);
            }

            var item = queue1.Dequeue();

            while (queue2.Count > 0)
                queue1.Enqueue(queue2.Dequeue());

            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return top;
        }

        public bool IsEmpty()
        {
            return queue1.Count == 0;
        }

        public int Size()
        {
            return queue1.Count;
        }
    }
}
