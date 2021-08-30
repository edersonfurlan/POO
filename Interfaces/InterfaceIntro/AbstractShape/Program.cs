using AbstractShape.Model.Entities;
using AbstractShape.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShape
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape s1 = new Circle() { Radius = 2.0, Color = Color.White };
            IShape s2 = new Rectangle() { Width = 3.5, Height = 4.5, Color = Color.Black };
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.ReadLine();
        }
    }
}
