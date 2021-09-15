using System;
using System.Collections.Generic;

namespace HashSortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("HashSet:");
            Console.WriteLine();
            Console.WriteLine();

            HashSet<string> set = new HashSet<string>();
            set.Add("TV");
            set.Add("Notebook");
            set.Add("Tablet");

            Console.WriteLine("Contains: " + set.Contains("Notebook"));

            foreach (string p in set)
                Console.WriteLine(p);

            Console.WriteLine();

            Console.WriteLine("SortedSet:");
            Console.WriteLine();

            SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
            SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

            //union
            SortedSet<int> c = new SortedSet<int>(a);
            c.UnionWith(b);
            Console.Write("Union: ");
            PrintCollection(c);

            //intersection
            SortedSet<int> d = new SortedSet<int>(a);
            d.IntersectWith(b);
            Console.Write("Intersection: ");
            PrintCollection(d);

            //difference
            SortedSet<int> e = new SortedSet<int>(a);
            e.ExceptWith(b);
            Console.Write("Difference: ");
            PrintCollection(e);
        }

        static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (T obj in collection)
            {
                Console.Write(obj + " ");                
            }
            Console.WriteLine();
        }
    }
}
