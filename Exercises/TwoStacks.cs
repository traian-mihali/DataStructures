using DataStructures.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exercises
{
    public class TwoStacks
    {
        private int[] _items;
        private int _top1;
        private int _top2;

        public TwoStacks(int size)
        {
            if (size < 1)
                throw new ArgumentOutOfRangeException("Size should be greater or equal to 1.");

            _items = new int[size];

            _top1 = -1;
            _top2 = size;
        }

        public void Push1(int item)
        {
            if (IsFull1())
                throw new InvalidOperationException();

            _items[++_top1] = item;
        }

        public void Push2(int item)
        {
            if (IsFull2())
                throw new InvalidOperationException();

            _items[--_top2] = item;
        }

        public int Pop1()
        {
            if (IsEmpty1())
                throw new InvalidOperationException();


            return _items[_top1--];
        }

        public int Pop2()
        {
            if (IsEmpty2())
                throw new InvalidOperationException();

            return _items[_top2++];
        }

        public bool IsEmpty1()
        {
            return _top1 == -1;
        }

        public bool IsEmpty2()
        {
            return _top2 == _items.Length;
        }

        public bool IsFull1()
        {
            return _top1 + 1 == _top2;
        }

        public bool IsFull2()
        {
            return _top2 - 1 == _top1;
        }
    }
}
