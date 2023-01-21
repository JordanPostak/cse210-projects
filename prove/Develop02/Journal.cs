using System;
using System.Collections.Generic;

namespace Develop02
{
    class Journal
    {
        public List<Entry> Entries { get; set; }

        public Journal()
        {
            Entries = new List<Entry>();
        }

        public void AddEntry(string prompt, string response, DateTime date)
        {
            Entry newEntry = new Entry(prompt, response, date);
            Entries.Add(newEntry);
        }

        public void DisplayEntries()
        {
            foreach (Entry entry in Entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }
    }
}