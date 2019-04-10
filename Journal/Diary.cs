using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Journal
{
    class Diary
    {
        private Database database;

        public Diary()
        {
            database = new Database();
        }

        private DateTime ReadDateTime()
        {
            Console.WriteLine("Enter a date and time. For example [01/01/2000 01:00]");
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                Console.WriteLine("Error. Please try again.");
            return dateTime;
        }

        private void PrintEntries(DateTime day) //Prints entry
        {
            List<Entry> entries = database.FindEntries(day, false);
            foreach (Entry entry in entries)
                Console.WriteLine(entry);
        }

        public void AddEntry()
        {
            DateTime dateTime = ReadDateTime();
            Console.WriteLine("Please enter the entry text: ");
            string text = Console.ReadLine();
            database.AddEntry(dateTime, text);
        }

        public void SearchEntry()
        {
            //Entering the date
            DateTime dateTime = ReadDateTime();
            //Searching for entries
            List<Entry> entries = database.FindEntries(dateTime, false);
            //Printing entries
            if(entries.Count() > 0)
            {
                Console.WriteLine("Entries found: ");
                foreach (Entry entry in entries)
                    Console.WriteLine(entry);
            }
            else
            {
                Console.WriteLine("Nothing was found."); //Nothing was found :p 
            }

        }

        public void DeleteEntries()
        {
            Console.WriteLine("Entries with the same date and time will be deleted.");
            DateTime dateTime = ReadDateTime();
            database.DeleteEntries(dateTime);
        }

        public void PrintHomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the your virtual journal.");
            Console.WriteLine("Today is: {0}", DateTime.Now);
            Console.WriteLine();
            //Printing the Homescreen
            Console.WriteLine("Today:\n-------");
            PrintEntries(DateTime.Today);
            Console.WriteLine();
            Console.WriteLine("Tomorrow:\n------");
            PrintEntries(DateTime.Now.AddDays(1));
            Console.WriteLine();
        }
    }
}
