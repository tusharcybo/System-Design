using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System_Design.SOLID_;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("tree", Color.Green, Size.Large);
            var house = new Product("house", Color.Red, Size.Yuge);

            Product[] products = {apple, tree, house};
            var pf = new ProductFilter();
            Console.WriteLine("Green Products: ");
            foreach(var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"- {p.Name} is green.");
            }

            Console.WriteLine("Green Products (New): ");

            var bf = new BetterFilter();
            foreach(var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"- {p.Name} is green.");
            }

            Console.WriteLine("Red and Large Products (New): ");
            foreach (var p in bf.Filter(products, new AndSpecification<Product> (new ColorSpecification(Color.Red), new SizeSpecification(Size.Yuge)))) {
                Console.WriteLine($"- {p.Name} is Red and Yuge.");
            }

            Console.ReadLine();
        }
    }

}
