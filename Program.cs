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
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has Area: {Area(rc)}");

            // Square sq = new Square(); // changing it to
            Rectangle sq = new Square(); // will break o/p Width: 2, Height: 0 has Area: 0
            sq.Width = 2; // Setting the width which means you are only setting the width

            Console.WriteLine($"{sq} has Area: {Area(sq)}");

            Console.ReadLine();
        }


        
    }

}
