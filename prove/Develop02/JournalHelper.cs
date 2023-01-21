using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Develop02
{

    class JournalHelper
    {
        public static void SaveJournal(Journal journal, string fileName)
        {
            string json = JsonSerializer.Serialize(journal);
            File.WriteAllText(fileName, json);
        }

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