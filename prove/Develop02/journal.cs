using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JournalProgram
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry entry) => _entries.Add(entry);

        public List<Entry> GetEntries() => _entries.OrderBy(e => e.Date).ToList();

        public void Save(string path)
        {
            var opt = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(path, JsonSerializer.Serialize(_entries, opt));
        }

        public static Journal Load(string path)
        {
            var text = File.ReadAllText(path);
            var list = JsonSerializer.Deserialize<List<Entry>>(text) ?? new List<Entry>();
            var j = new Journal();
            foreach (var e in list) j.AddEntry(e);
            return j;
        }
    }
}
