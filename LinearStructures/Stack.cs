using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class Stack
    {
        private int[] stack;
        private int count;

        public Stack(int size)
        {
            stack = new int[size];
        }

        public void Push(int item)
        {
            if (count == stack.Length)
                throw new StackOverflowException();

            stack[count++] = item;
        }

        public int Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");
            
            return stack[--count];
        }

        public int Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");

            return stack[count - 1];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

    }
}
