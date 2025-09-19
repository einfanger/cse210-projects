using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What grade do you have in the class?");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";
        if (percent >= 90)
        {
            letter = "A";

        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"You have a: {letter}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You killed it!");
        }
        else
        {
            Console.WriteLine("Hit the books and you'll see results! Studying.. I mean. Don't actually hit the books, they're probably expensive.");
        }
    }
}