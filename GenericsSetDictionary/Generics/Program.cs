using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////print int
            PrintService<int> printServiceInt = new PrintService<int>();

            Console.Write("How many int values? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                printServiceInt.addValue(x);
            }

            printServiceInt.Print();
            Console.WriteLine();
            Console.WriteLine("First int: " + printServiceInt.First());

            Console.WriteLine();
            Console.WriteLine();

            /////////////////////////////////////////////////////////print string
            PrintService<string> printServiceString = new PrintService<string>();

            Console.Write("How many string values? ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string y = Console.ReadLine();
                printServiceString.addValue(y);
            }

            printServiceString.Print();
            Console.WriteLine();
            Console.WriteLine("First string: " + printServiceString.First());
        }
    }
}
