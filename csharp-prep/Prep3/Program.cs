using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Guess My Number ===");
        Console.Write("Do you want to pick the magic number yourself? (yes/no): ");
        string choice = (Console.ReadLine() ?? "").Trim().ToLower();

        int magicNumber;
        if (choice == "yes" || choice == "y")
        {
            while (true)
            {
                Console.Write("Enter the magic number (1-100): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out magicNumber) && magicNumber >= 1 && magicNumber <= 100)
                {
                    Console.WriteLine("\n\n\n\n\n");  
                    Console.WriteLine("Okay — magic number saved. Now try to guess it!");
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a valid number between 1 and 100. Try again.");
                }
            }
        }
        else
        {
            Random randomGenerator = new Random();
            magicNumber = randomGenerator.Next(1, 101);
            Console.WriteLine("I've picked a number between 1 and 100. Try to guess it!");
        }

        int guess;
        int attempts = 0;

        do
        {
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();

            if (!int.TryParse(guessInput, out guess))
            {
                Console.WriteLine("Please type a valid integer.");
                continue;
            }

            attempts++;
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
        } while (guess != magicNumber);
        Console.WriteLine($"You guessed it! The number was {magicNumber}.");
        Console.WriteLine($"Attempts: {attempts}");
    }
}
