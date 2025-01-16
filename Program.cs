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
            Person parent = new Person { Name = "John" };
            Person child1 = new Person { Name = "Chris" };
            Person child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAddChild(parent, child1);
            relationships.AddParentAddChild(parent, child2);

            new Research(relationships);
            Console.ReadLine();
        }


        
    }

}
