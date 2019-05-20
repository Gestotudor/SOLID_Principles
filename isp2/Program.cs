using System;

namespace DotNetDesignPatternDemos.SOLID.InterfaceSegregationPrinciple
{
    // Interface'ler cok buyuk olmamali amaclarina gore farkli interface'lere bolunmeli
    // Boylece buyuk interface'lerden bazi methodlari bos birakan class'lar yapmayiz

    // ISTEK: Fax ve Scan methodlari bos olan Machine icin nasil sade interfaceler olusturmaliyiz?

    public class Document
    {
    }

    //public interface IMachine
    //{
    //    void Print(Document d);
    //    void Fax(Document d);
    //    void Scan(Document d);
    //}

    // ok if you need a multifunction machine
    //public class MultiFunctionPrinter : IMachine
    //{
    //    public void Print(Document d)
    //    {
    //        //
    //    }

    //    public void Fax(Document d)
    //    {
    //        //
    //    }

    //    public void Scan(Document d)
    //    {
    //        //
    //    }
    //}

    //public class OldFashionedPrinter : IMachine
    //{
    //    public void Print(Document d)
    //    {
    //        // yep
    //    }

    //    public void Fax(Document d)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void Scan(Document d)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {

        }
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //;
        }

        public void Scan(Document d)
        {
            //;
        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner //
    {

    }

    public struct MultiFunctionMachine : IMultiFunctionDevice
    {
        // compose this out of several modules (delegation kullanmis-yani baska class'ta yapilan implementation'i kullaniyor)
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
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