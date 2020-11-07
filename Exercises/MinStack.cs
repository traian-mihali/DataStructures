using DataStructures.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    public class MinStack
    {
        private Stack _stack;
        private Stack _minStack;

        public MinStack(int size)
        {
            _stack = new Stack(size);
            _minStack = new Stack(size);
        }

        public void Push(int item)
        {
            _stack.Push(item);

            if (_minStack.IsEmpty())
                _minStack.Push(item);
            else if (item < _minStack.Peek())
                _minStack.Push(item);
        }

        public int Pop()
        {
            var top = _stack.Pop();

            if (top == _minStack.Peek())
                _minStack.Pop();

            return top;
        }

        public int Min()
        {
            return _minStack.Peek();
        }
    }
}
