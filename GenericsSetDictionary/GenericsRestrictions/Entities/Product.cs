﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GenericsRestrictions.Entities
{
    class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name
                + ","
                + Price.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Product))
                throw new ArgumentException("Comparing error: argument is not product");

            Product other = obj as Product;
            return Price.CompareTo(other.Price);
        }
    }
}
