using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 2, 3, 4, 5 };

            //IEnumerable é um tipo mais genérico
            IEnumerable<int> result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10);

            foreach (int x in result)
                Console.WriteLine(x);
        }
    }
}
