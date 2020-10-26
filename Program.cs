﻿using DataStructures.LinearStructures;
using System;
using System.Collections;
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
            //TestArray();
            TestLinkedList();

            Console.ReadLine();
        }

        static void TestArray()
        {
            var array = new LinearStructures.Array(3);

            array.Insert(1);
            array.Insert(2);
            array.Insert(3);
            array.Print();


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REMOVE FROM INDEX 0");
            array.RemoveAt(0);
            array.Print();

            Console.WriteLine("INSERT 1 AT INDEX 0");
            array.InsertAt(0, 1);
            array.Print();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REVERSED ARRAY");
            var reversed = array.Reverse();
            foreach (var item in reversed)
                Console.WriteLine(item);


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("INTERSECTION WITH [1, 4]");
            var other = new LinearStructures.Array(2);
            other.Insert(1);
            other.Insert(4);
            var intersection = array.Intersect(other);
            intersection.Print();
        }

        static void TestLinkedList()
        {
            var list = new LinkedList();

            //list.AddFirst(10);
            //list.AddFirst(20);
            //list.AddFirst(30);
            //list.Print();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);
            list.Print();

            var loopList = LinkedList.CreateLoop();
            Console.WriteLine("HAS LOOP: " + loopList.HasLoop());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("LIST MIDDLE VALUE: ");
            list.PrintMiddle();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("kth is 1: " + list.GetKthFromTheEnd(1));
            Console.WriteLine("kth is 2: " + list.GetKthFromTheEnd(2));
            Console.WriteLine("kth is 3: " + list.GetKthFromTheEnd(3));



            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST SIZE: " + list.Size);

            //Console.WriteLine(Environment.NewLine);
            //list.RemoveFirst();
            //list.Print();

            //Console.WriteLine(Environment.NewLine);
            //list.RemoveLast();
            //list.Print();


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("INDEX OF 10: " + list.IndexOf(10));
            Console.WriteLine("INDEX OF 20: " + list.IndexOf(20));
            Console.WriteLine("INDEX OF 30: " + list.IndexOf(30));
            Console.WriteLine("INDEX OF 40: " + list.IndexOf(40));


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("CONTAINS 10: " + list.Contains(10));
            Console.WriteLine("CONTAINS 20: " + list.Contains(20));
            Console.WriteLine("CONTAINS 30: " + list.Contains(30));
            Console.WriteLine("CONTAINS 40: " + list.Contains(40));

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST SIZE: " + list.Size);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST TO ARRAY: " + String.Join(", ", list.ToArray()));

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("REVERSE LINKEDLIST");
            list.Reverse();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("LINKEDLIST TO ARRAY: " + String.Join(", ", list.ToArray()));
        }
    }
}
