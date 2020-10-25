using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new LinearStructures.Array(3);

            array.Insert(1);
            array.Insert(2);
            array.Insert(3);

            array.Print();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("REMOVE FROM INDEX 0");
            var deleted = array.RemoveAt(0);
            Console.WriteLine("ITEM REMOVED: " + deleted);
            array.Print();

            Console.WriteLine("INSERT 1 AT INDEX 0");
            array.InsertAt(0, 1);
            array.Print();

            var reversed = array.Reverse();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REVERSED ARRAY");
            foreach (var item in reversed)
                Console.WriteLine(item);


            Console.WriteLine(Environment.NewLine);

            var other = new LinearStructures.Array(2);
            other.Insert(1);
            other.Insert(4);

            Console.WriteLine("INTERSECTION WITH [1, 4]");
            var intersection = array.Intersect(other);
            intersection.Print();

            Console.ReadLine();
        }
    }
}
