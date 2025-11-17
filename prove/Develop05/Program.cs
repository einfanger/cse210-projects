
using System;

class Program
{
    static void Main()
    {
        QuestManager qm = new QuestManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("0. Quit");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(qm);
                    break;

                case "2":
                    qm.ListGoals();
                    break;

                case "3":
                    Console.Write("Goal number: ");
                    int n = int.Parse(Console.ReadLine()) - 1;
                    qm.RecordEvent(n);
                    break;

                case "4":
                    Console.Write("Filename: ");
                    qm.Save(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Filename: ");
                    qm.Load(Console.ReadLine());
                    break;

                case "6":
                    Console.WriteLine($"Score: {qm.Score}");
                    break;

                case "0":
                    running = false;
                    break;
            }
        }
    }

    static void CreateGoal(QuestManager qm)
    {
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write("Type: ");

        string type = Console.ReadLine();

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            qm.AddGoal(new SimpleGoal(title, desc, points));
        }
        else if (type == "2")
        {
            qm.AddGoal(new EternalGoal(title, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Required count: ");
            int req = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            qm.AddGoal(new ChecklistGoal(title, desc, points, req, bonus));
        }

        Console.WriteLine("Goal created.");
    }
}
