
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

        // The AddEntry() method creates a new Entry object with the given prompt, response, and date,
        // and adds it to the Entries list.
        public void AddEntry(string prompt, string response, DateTime date)
        {
            Entry newEntry = new Entry(prompt, response, date);
            Entries.Add(newEntry);
        }

        // The DisplayEntries() method iterates through the Entries list and calls the Display() method of each Entry.
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