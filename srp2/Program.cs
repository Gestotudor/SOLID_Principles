using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.SRP
{
    // Her component tek bir amac icin degistirilmeli ve her component'in tek bir gorevi olmali

    // just stores a couple of journal entries and ways of
    // working with them
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            //string interpolation...
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            // Join ayrıştırıcıyı spesifik hale getiriyioruz.
            return string.Join(Environment.NewLine, entries);
        }

        //ToString MEtodunu override Ettik.


        // breaks single responsibility principle

    }
    public class Persistence
    {

        public void Save(string filename, Journal journal, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }


        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }



    }
    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            j.AddEntry("I learned S of SOLID principle.");
            WriteLine(j);
            var t = new Persistence();
            var filename = @"c:\temp\journal.txt";
            t.Save(filename, j, overwrite: true);
            // dosya adresini bulup çalıştırıyor.
            Process.Start(filename);
        }
    }
}