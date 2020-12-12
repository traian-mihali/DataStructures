using DataStructures.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    public class QueueWithTwoStacks
    {
        private Stack stackEnqueue;
        private Stack stackDequeue;

        public QueueWithTwoStacks(int capacity)
        {
            stackEnqueue = new Stack(capacity);
            stackDequeue = new Stack(capacity);
        }

        public void Enqueue(int item)
        {
            stackEnqueue.Push(item);
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            MoveEnqueueStackToDequeue();

            return stackDequeue.Pop();
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            MoveEnqueueStackToDequeue();

            return stackDequeue.Peek();
        }

        public void MoveEnqueueStackToDequeue()
        {
            if (stackDequeue.IsEmpty())
            {
                while (!stackEnqueue.IsEmpty())
                    stackDequeue.Push(stackEnqueue.Pop());
            }
        }

        public bool IsEmpty()
        {
            return stackEnqueue.IsEmpty() && stackDequeue.IsEmpty();
        }
    }
}
