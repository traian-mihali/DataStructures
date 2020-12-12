using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    public class QueueReverser
    {
        public static Queue<int> Reverse(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            return queue;
        }

        public static Queue<int> ReverseUpToKth(Queue<int> queue, int kth)
        {
            if (kth < 0 || kth > queue.Count)
                throw new InvalidOperationException("Invalid kth element.");

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < kth; i++)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            for (int i = 0; i < queue.Count - kth; i++)
                queue.Enqueue(queue.Dequeue());

            return queue;
        }
    }
}
