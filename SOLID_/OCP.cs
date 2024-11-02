using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System_Design.SOLID_
{
    /*
     Open/Closed Principle Overview
Definition:
Parts of a system(or subsystems) should be open for extension but closed for modification.
New functionality can be added without changing existing code.
Implementation in Filtering Example
Objective:

Find items that meet specific criteria(e.g., large blue items).
Class Structure:

BetterFilter: A class responsible for filtering items based on various criteria.
Specification Pattern:
Uses separate classes to define filtering criteria (e.g., ColorSpecification, SizeSpecification).
Composite Specification:

To filter by multiple criteria, an AndSpecification is used to combine different specifications.
Example criteria:
Color: Blue
Size: Large
Filtering Process:

The BetterFilter takes the composite specification and iterates through the items.
Each item is checked against the combined criteria.
In the example, the filter successfully returns a blue house, indicating a match.
Key Benefits of the Open/Closed Principle
Avoids Modification: Existing classes (like BetterFilter) do not need to be altered when adding new specifications.
Encourages Reusability: New specifications can be created as needed without affecting the core functionality.
Supports Extensibility: Additional functionality can be provided through new classes, allowing for a more flexible and maintainable design.
Recap of the Open/Closed Principle
Aim for designs where functionality can be extended through new classes rather than modifying existing ones.
This design philosophy facilitates shipping new features or modules without disrupting existing code that is already in use by customers.
    */

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
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                    yield return p;
            }
        }
        
    }
    
    public interface ISpecification<T>
    {
        bool IsSatasfied(T t);
    }

   
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    //the types here can be virtually anything but we're filtering products.
    public class ColorSpecification : ISpecification<Product>
    {
        private Color Color;
        public ColorSpecification(Color color)
        {
            Color = color;
        }
        public bool IsSatasfied(Product t)
        {
            return t.Color == Color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size Size;

        public SizeSpecification(Size size)
        {
            Size = size;
        }

        public bool IsSatasfied(Product p)
        {
            return p.Size == Size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(first));
        }
        public bool IsSatasfied(T t)
        {
            return first.IsSatasfied(t) && second.IsSatasfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        // it's going to be a generic one
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(var i in items)
            {
                if (spec.IsSatasfied(i))
                    yield return i;
            }
        }
    }
    class OCP
    {
        /*
        static void Main(string[] args)
        {

            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("tree", Color.Green, Size.Large);
            var house = new Product("house", Color.Red, Size.Yuge);

            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            Console.WriteLine("Green Products: ");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"- {p.Name} is green.");
            }

            Console.WriteLine("Green Products (New): ");

            var bf = new BetterFilter();
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"- {p.Name} is green.");
            }

            Console.WriteLine("Red and Large Products (New): ");
            foreach (var p in bf.Filter(products, new AndSpecification<Product> (new ColorSpecification(Color.Red), new SizeSpecification(Size.Yuge)))) {
                Console.WriteLine($"- {p.Name} is Red and Yuge.");
            }

            Console.ReadLine();
        }
        */
    }
}
