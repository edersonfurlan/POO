﻿using DemoLINQProduct.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLINQProduct
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70, Category = c1 },
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900: ", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS: ", r2);

            var r3 = products.Where(p => p.Name[0] == 'P').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            //var r3 = products.Where(p => p.Name.StartsWith("P")).Select(p => p.Name);
            Print("PRODUCTS START WITH LETTER P: ", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME: ", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4: ", r5);

            var r6 = products.First();
            Console.WriteLine("FIRST TEST 1: " + r6);

            //First or default deve retornar o primeiro ou nenhum elemento
            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("FIRST OR DEFAULT: " + r7);

            //Single or default deve retornar 1 ou nenhum elemento
            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT: " + r8);

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT 2: " + r9);

            Console.WriteLine();

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("MAX PRICE: " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("MIN PRICE: " + r11);

            var r12 = products.Where(P => P.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("CATEGORY 1 SUM PRICES: " + r12);

            var r13 = products.Where(P => P.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("CATEGORY 1 AVERAGE PRICES: " + r13);

            var r14 = products.Where(P => P.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("CATEGORY 5 AVERAGE PRICES: " + r14);

            var r15 = products.Where(P => P.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("CATEGORY 1 AGGREGATE PRICES: " + r15);

            Console.WriteLine();

            var r16 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category,Product> group in r16)
            {
                Console.WriteLine("Category: " + group.Key.Name + ":");
                foreach (Product p in group)
                    Console.WriteLine(p);

                Console.WriteLine();
            }

            //sintaxes alternativas - LINQ com notação similar à SQL
            Console.WriteLine("SINTAXE ALTERNATIVA - LINQ COM NOTAÇÃO SIMILAR À SQL");
            Console.WriteLine();

            var r17 = from p in products
                      where p.Category.Tier == 1 && p.Price < 900.0
                      select p;

            Print("TIER 1 AND PRICE < 900: ", r17);

            var r18 = from p in products
                      where p.Category.Name == "Tools"
                      select p.Name;
            
            Print("NAMES OF PRODUCTS FROM TOOLS: ", r18);

            var r19 = from p in products
                      where p.Name[0] == 'P'
                      select new
                      {
                          p.Name,
                          p.Price,
                          CategoryName = p.Category.Name
                      };

            Print("PRODUCTS START WITH LETTER P: ", r19);

            var r20 = from p in products
                      where p.Category.Tier == 1
                      orderby p.Name
                      orderby p.Price
                      select p;

            Print("TIER 1 ORDER BY PRICE THEN BY NAME: ", r20);

            var r21 = (from p in r20 select p).Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4: ", r21);

            Console.WriteLine();

            var r22 = from p in products
                      group p by p.Category;

            foreach (IGrouping<Category, Product> group in r22)
            {
                Console.WriteLine("Category: " + group.Key.Name + ":");
                foreach (Product p in group)
                    Console.WriteLine(p);

                Console.WriteLine();
            }
        }
    }
}
