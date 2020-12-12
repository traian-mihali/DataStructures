using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class PriorityQueue
    {
        private int[] items = new int[5];
        private int count;

        public void Add(int item)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full.");

            int i = ShiftItemsToInsert(item);
            items[i] = item;
            count++;
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return items[--count];
        }

        public int ShiftItemsToInsert(int item)
        {
            int i;
            for (i = count - 1; i >= 0; i--)
            {
                if (items[i] > item)
                    items[i + 1] = items[i];
                else
                    break;
            }

            return i + 1;
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
