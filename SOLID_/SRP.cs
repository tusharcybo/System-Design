﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace System_Design.SOLID_
{
    /*The Single Responsibility Principle(SRP) from the SOLID principles, emphasizing that a class should have only one reason to change.This means a class should focus on one aspect of the system to avoid overlapping responsibilities, which can lead to maintenance challenges.

To illustrate SRP, the example uses a "Journal" class that starts by keeping track of entries.Initially, the Journal class has methods to add and remove entries and to generate a string representation of them, which aligns with SRP since all methods relate to journal functionality.However, as more features are added—like saving and loading the journal from a file—the Journal class begins handling persistence, which deviates from SRP.

The suggested solution is to create a separate "Persistence" class responsible for saving and loading data.This class would handle tasks related to storage, keeping the Journal class focused solely on managing entries.

Benefits of Applying SRP in this Example:


Modularity: The journal management and data storage are separated, so changes in one functionality (e.g., saving to a new format) don’t affect the journal structure.
Scalability: This modularity makes the system easier to extend or modify.
Maintainability: By keeping classes focused on single tasks, debugging and testing become more straightforward.
SRP is essential for creating cleaner, more manageable code that can evolve over time without introducing unnecessary complexity.*/
    class SRP
    {
        //Single Responsibility Principle
        /* 
        static void Main(string[] args)
        {

            var j = new Journal();
            j.AddEntry("I cried Today.");
            j.AddEntry("I ate a Bug.");
            Console.WriteLine(j);

            var filename = @"C:/temp/journal.txt";
            Persistence p = new Persistence();
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
            Console.ReadLine();
        }
        */
    }

    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        public static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries.ToArray());
        }

        /*
        public void SaveToFile()
        {   
        }

        public void LoadFile()
        {
        }

        */
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

}
