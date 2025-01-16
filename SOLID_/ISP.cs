using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System_Design.SOLID_
{
    // Interface Segregation Principle
    class ISP
    {

    }

    public class Document
    { 
        
    }

    /*
     ISP focuses on creating smaller, more specific interfaces rather than one large interface with many methods. 
                         
    The example begins by describing a scenario where a large interface, IMachine, contains methods for printing, scanning, and faxing. This works well for a multifunction printer, but it creates a problem when you want to create a simple printer that doesn’t need scanning or faxing.

    Dilemma with Large Interfaces: When implementing the IMachine interface with a basic printer, you have to either:

    Leave unimplemented methods (scan and fax) throwing exceptions or doing nothing, which is confusing for API consumers.
    Document that some methods are unsupported, leading to unclear expectations.
    Solution with Smaller Interfaces: ISP suggests splitting the larger interface into smaller, more focused interfaces. For example, you could have:

    IPrinter with a print method.
    IScanner with a scan method.
    This allows each class to implement only the interfaces it needs, avoiding unnecessary methods.

    Combining Smaller Interfaces: You can create a higher-level interface like IMultiFunctionDevice that inherits from IPrinter and IScanner, providing flexibility without forcing implementations of unrelated methods.

    Using Composition and Delegation: When implementing a multifunction device, you can delegate calls to individual printer and scanner objects instead of having them all in one class. This illustrates the decorator pattern, which allows the multifunction class to delegate tasks to its composed objects.

    Overall, the ISP encourages avoiding "fat" interfaces and promotes the use of multiple, smaller, and more specific interfaces, making the code cleaner, more modular, and less error-prone.
     */

    
    public interface IMachine 
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }
        public void Scan(Document d)
        {
            //
        }
        public void Fax(Document d)
        {
            //
        }
    }

    public class OldPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public interface IMultifunctionDevice : IPrinter, IScanner
    {
        
    }

    public class MultifunctionDevice : IMultifunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultifunctionDevice(IPrinter printer, IScanner scanner)
        {
            if(printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if(scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            this.printer = printer;
            this.scanner = scanner; 
        }
        public void Print(Document d)
        {
            printer.Print(d);
        }
        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }

}
