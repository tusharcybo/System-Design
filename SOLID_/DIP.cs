using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System_Design.SOLID_
{
    // Dipendency Inversion Principle

    /*The Dependency Inversion Principle(DIP) is a key principle in software development, emphasizing that high-level modules(which contain important business logic) should not directly depend on low-level modules(which deal with specific details, like database or I/O operations). Instead, both should depend on abstractions(like interfaces or abstract classes). This setup reduces tight coupling between different parts of the system, making the code easier to test, extend, and modify.

To illustrate this, imagine a genealogy application where we have people and relationships between them (like parent-child). Here, high-level modules might be components that perform research or queries on relationships. In contrast, low-level modules are the classes defining how relationships are stored or retrieved. DIP would mean our high-level modules interact with the relationship data indirectly through an abstraction, rather than accessing data directly. This way, if we change the data storage method, we don’t need to modify the high-level logic.

In the example from the transcript:

Define relationships between people using a class Relationships.
Add relationships like Parent and Child through low-level data structures(e.g., a list of Person objects and their relationships).
Perform research: The Research class (high-level) initially tries to access relationships by accessing private fields or methods of Relationships.However, according to DIP, Research should instead interact with an abstraction that defines the way it can access relationships, rather than the data directly.
By implementing DIP, you make the code structure flexible, where changes in data handling don’t force changes in higher-level business logic.*/








    public enum Relation
    {
        Parent,
        Child,
        Siblings
    }

    public class Person
    {
        public string Name;
        // public DateTime dateOfBith;
    }

    // Better Low-Level System

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // Low-Level System
    public class Relationships : IRelationshipBrowser
    {
        List<(Person, Relation, Person)> relations = new List<(Person, Relation, Person)>();

        public void AddParentAddChild(Person parent, Person child)
        {
            relations.Add((parent, Relation.Parent, child));
            relations.Add((child, Relation.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(
                x => x.Item1.Name == name &&
                x.Item2 == Relation.Parent
                ).Select(r => r.Item3);
        }

        //public List<(Person, Relation, Person)> Relations => relations;
    }




    public class Research
    {
        /*public Research(Relationships relationships)
        {
            var relations = relationships.Relations;
            foreach (var r in relations.Where(
                x => x.Item1.Name == "John" &&
                x.Item2 == Relation.Parent
                ))
            {
                Console.WriteLine($"John has a child called {r.Item3.Name}");
            }
        }*/

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                Console.WriteLine($"John has  a child called {p.Name}");
        }

        /*
        static void Main(string[] args)
        {
            Person parent = new Person { Name = "John" };
            Person child1 = new Person { Name = "Chris" };
            Person child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAddChild(parent, child1);
            relationships.AddParentAddChild(parent, child2);

            new Research(relationships);
        }
        */
    }
    class DIP
    {
        
    }
}
