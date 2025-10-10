using System;

namespace JournalProgram
{
    class Program
    {
        static string DataFile => "journal.json";
        static Journal _journal;
        static PromptProvider _prompts;

        static void Main(string[] args)
        {
            _prompts = new PromptProvider();
            _journal = File.Exists(DataFile) ? Journal.Load(DataFile) : new Journal();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Journal Menu:");
                Console.WriteLine("1) Write new entry");
                Console.WriteLine("2) Display journal");
                Console.WriteLine("3) Save journal to file");
                Console.WriteLine("4) Load journal from file");
                Console.WriteLine("0) Exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine() ?? "";
                Console.WriteLine();
                switch (choice)
                {
                    case "1": WriteEntry(); break;
                    case "2": DisplayJournal(); break;
                    case "3": SaveToFile(); break;
                    case "4": LoadFromFile(); break;
                    case "0": _journal.Save(DataFile); return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        static void WriteEntry()
        {
            var prompt = _prompts.GetRandomPrompt();
            Console.WriteLine("Prompt:");
            Console.WriteLine(prompt);
            Console.WriteLine("Write your response. End with a single line containing only .done");
            var lines = new List<string>();
            while (true)
            {
                var line = Console.ReadLine() ?? "";
                if (line.Trim() == ".done") break;
                lines.Add(line);
            }
            var content = string.Join(Environment.NewLine, lines);
            Console.Write("Mood (1–5, 1=bad, 5=great): ");
            var moodInput = Console.ReadLine() ?? "3";
            int mood = int.TryParse(moodInput, out var m) ? Math.Clamp(m, 1, 5) : 3;
            var entry = new Entry(prompt, content, DateTime.Now.ToString("yyyy-MM-dd HH:mm"), mood);
            _journal.AddEntry(entry);
            Console.WriteLine("Entry saved.");
        }

        static void DisplayJournal()
        {
            var entries = _journal.GetEntries();
            if (!entries.Any()) { Console.WriteLine("No entries."); return; }
            for (int i = 0; i < entries.Count; i++)
            {
                var e = entries[i];
                int wordCount = e.Content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"--- Entry {i + 1} ---");
                Console.WriteLine($"Date: {e.Date}");
                Console.WriteLine($"Prompt: {e.Prompt}");
                Console.WriteLine($"Mood: {e.Mood}/5");
                Console.WriteLine($"Word Count: {wordCount}");
                Console.WriteLine("Response:");
                Console.WriteLine(e.Content);
                Console.WriteLine();
            }
        }

        static void SaveToFile()
        {
            Console.Write("Filename to save (default journal.json): ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = "journal.json";
            _journal.Save(name);
            Console.WriteLine($"Saved to {name}");
        }

        static void LoadFromFile()
        {
            Console.Write("Filename to load (default journal.json): ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = "journal.json";
            if (!File.Exists(name)) { Console.WriteLine("File not found."); return; }
            _journal = Journal.Load(name);
            Console.WriteLine("Journal loaded and replaced current entries.");
        }
    }
}
