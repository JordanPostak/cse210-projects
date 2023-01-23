using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Develop02
{

    class JournalHelper
    {
        // SaveJournal() method takes in a Journal object and a file name and serializes the journal object to json format
        // and writes it to the file specified by the file name
        public static void SaveJournal(Journal journal, string fileName)
        {
            string json = JsonSerializer.Serialize(journal);
            File.WriteAllText(fileName, json);
        }

        // LoadJournal() method takes in a file name and deserializes the json data from the file to a Journal object
        // and returns it. If the file does not exist, it returns a new Journal object.
        public static Journal LoadJournal(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new Journal();
            }
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Journal>(json);
        }
    }
}