using System;

public class MenuUI
{
    private RecipeManager manager = new RecipeManager();

    public void ShowMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Digital Cookbook ===");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View Recipes");
            Console.WriteLine("3. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddRecipe();
                    break;
                case "2":
                    manager.GetAllRecipes();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
