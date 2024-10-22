using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace System_Design.SOLID_
{
    class SRP
    {
        /* Single Responsibility Principle
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
