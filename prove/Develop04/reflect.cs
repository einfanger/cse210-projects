using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you helped someone in need.",
        "Recall a time you overcame something difficult.",
        "Remember a moment when you felt truly at peace."
    };

    private List<string> _questions = new List<string>
    {
        "Why was that experience meaningful to you?",
        "What did you learn from it?",
        "How can you apply that lesson to your life now?"
    };

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on times of strength and growth.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine("\n" + _questions[rand.Next(_questions.Count)]);
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }
}
