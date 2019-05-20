using System;
using System.Collections.Generic;
using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.OCP
{
    // Class'lar gelisime acik ama degisime kapali olmali
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            //nulll ise ata.. 
            //  Name=name!=null ? name : throw <-- eski hali
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }


    public class ProductFilter
    {
        // let's suppose we don't want ad-hoc queries on products

            //yield ile yapılan return  işlemleri döngülerden geri dönerken kaldığı yere devam ediyor.
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }

        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
                if (p.Size == size && p.Color == color)
                    yield return p;
        } // state space explosion
          // 3 criteria = 7 methods

        // OCP = open for extension but closed for modification
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            //object initil.
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                WriteLine($" - {p.Name} is green");
        }
    }
}
