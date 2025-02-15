﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System_Design.SOLID_
{
    // Liskov Substitution Principle
    public class Rectangle
    {
        // public int Width -> old
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle()
        {
        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
     // new -> Override
        public override int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
        public override int Height
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
    }
    /*
    Create Rectangle. create Square from Rectangle. Everything is working.
    Why are we even discussing this strange substitution principle. 
    the reason for this is that if you have a square then it is perfectly legal for you to store 
    a reference to a square as a rectangle variable because remember inheritance basically a square is a rectangle.
    // Square sq = new Square(); // changing it to
       Rectangle sq = new Square(); // will break o/p Width: 2, Height: 0 has Area: 0
    */

    /*
     So the Liskov Substitution Principle basically says that you should always be able to sort 
    of upcast to a base type and the operation should still be generally OK.
    Meaning that this square should still behave as a square even when you're getting a reference 
    to a rectangle for it. 
    So the question is how do we fix this violation of the Liskov Substitution Principle. 
    And the fix is actually rather easy. All you have to do is you have to make sure that if there is in fact an
    override all within highe it is indicated as such because what we've done here is we've used the new keyword but
    instead what we can do is we could do something better we could make the properties virtual So it could go up 
    and And then of course instead of new you would food override and override here as well.

     */

    class LSP
    {
        /*
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has Area: {Area(rc)}");

            // Square sq = new Square(); // changing it to
            Rectangle sq = new Square(); // will break o/p Width: 2, Height: 0 has Area: 0
            sq.Width = 2; // Setting the width which means you are only setting the width

            Console.WriteLine($"{sq} has Area: {Area(sq)}");

            Console.ReadLine();
        }
        */
    }

}
