using Actions.Entities;
using System;
using System.Collections.Generic;

namespace Actions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            //opcional
            //Action<Product> act = p => { p.Price += p.Price * 0.1; };

            list.ForEach(p => { p.Price += p.Price * 0.1; });

            foreach (Product p in list)
                Console.WriteLine(p);
        }
    }
}
