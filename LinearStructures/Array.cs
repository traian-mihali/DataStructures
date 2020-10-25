using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class Array
    {
        private int[] _items = null;
        private int _count = 0;

        public Array(int size)
        {
            _items = new int[size];
        }


        public void Insert(int item)
        {
            Resize();

            _items[_count++] = item;
        }

        public void InsertAt(int index, int item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentException();

            Resize();

            for (var i = _count - 1; i >= index; i--)
                _items[i + 1] = _items[i];

            _items[index] = item;

            _count++;
        }

        public int IndexOf(int item)
        {
            for (var i = 0; i < _count; i++)
                if (_items[i] == item)
                    return i;

            return -1;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentException();

            var deleted = _items[index];

            for (var i = index; i < _count - 1; i++)
                _items[i] = _items[i + 1];

            _count--;

            return deleted;
        }

        public int[] Reverse()
        {
            int[] newItems = new int[_count];

            for (var i = 0; i < _count; i++)
                newItems[i] = _items[_count - i - 1];

            return newItems;
        }

        public int Max()
        {
            var max = 0;

            foreach (var item in _items)
            {
                if (item > max)
                    max = item;
            }

            return max;
        }

        public Array Intersect(Array other)
        {
            var intersection = new Array(_count);

            foreach (var item in _items)
                if (other.IndexOf(item) >= 0)
                    intersection.Insert(item);

            return intersection;
        }

        public void Print()
        {
            for (int i = 0; i < _count; i++)
                Console.WriteLine(_items[i]);
        }

        private void Resize()
        {
            if (_items.Length == _count)
            {
                int[] newItems = new int[_count * 2];

                for (int i = 0; i < _count; i++)
                    newItems[i] = _items[i];

                _items = newItems;
            }
        }
    }
}
