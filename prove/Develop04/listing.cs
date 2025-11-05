using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List as many things as you’re grateful for.",
        "List people who make you happy.",
        "List things you’re looking forward to."
    };

    public ListingActivity()
        : base("Listing", "This activity helps you think positively by listing good things in your life.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Start listing! (Press Enter after each item)");

        DateTime end = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        DisplayEndingMessage();
    }
}
