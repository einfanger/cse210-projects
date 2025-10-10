using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalProgram
{
    public class PromptProvider
    {
        private List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What am I grateful for today?",
            "What challenge did I overcome today?",
            "If I could do one thing over today, what would it be?",
            "What made me smile today?",
            "What did I learn about myself today?",
            "What was the hardest part of today, and how did I push through?",
            "What good deeds did I do today?",
        };

        private Random _rand = new Random();

        public string GetRandomPrompt()
        {
            if (!_prompts.Any()) return "Write something about your day.";
            return _prompts[_rand.Next(_prompts.Count)];
        }
    }
}
