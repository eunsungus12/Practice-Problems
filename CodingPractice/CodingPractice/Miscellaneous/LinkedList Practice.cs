using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    class LinkedList_Practice
    {
        public static void Test()
        {
            var list = new LinkedList<int>();
            var pointer = list;
            list.AddFirst(0);
            list.AddLast(1);
            var pointerSecond = pointer.Last;
            list.AddLast(2);
            list.AddLast(3);
            Console.WriteLine(pointer.First.Value);
            Console.WriteLine(pointer.Last.Value);
        }
    }
}
