using System;

public class MenuUI
{
    private RecipeManager manager = new RecipeManager();

    public void ShowMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== DIGITAL COOKBOOK ===");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View All Recipes");
            Console.WriteLine("3. Search Recipes");
            Console.WriteLine("4. Delete Recipe");
            Console.WriteLine("5. Favorite a Recipe");
            Console.WriteLine("6. View Favorites");
            Console.WriteLine("7. Export Recipe");
            Console.WriteLine("8. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddRecipe();
                    break;

                case "2":
                    manager.DisplayAll();
                    break;

                case "3":
                    manager.Search();
                    break;

                case "4":
                    manager.Delete();
                    break;

                case "5":
                    manager.MarkFavorite();
                    break;

                case "6":
                    manager.ShowFavorites();
                    break;

                case "7":
                    manager.ExportRecipe();
                    break;

                case "8":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, bro. Try again.");
                    break;
            }
        }
    }
}
