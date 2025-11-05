using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                new BreathingActivity().Run();
            }
            else if (choice == 2)
            {
                new ReflectingActivity().Run();
            }
            else if (choice == 3)
            {
                new ListingActivity().Run();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again!");
            }
        }
    }
}
