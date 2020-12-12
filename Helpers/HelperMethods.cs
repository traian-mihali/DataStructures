﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Helpers
{
    public class HelperMethods
    {
        public static Queue<int> ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            return queue;
        }
    }
}
