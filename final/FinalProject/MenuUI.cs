using System;

public class MenuUI
{
    private RecipeManager _manager = new RecipeManager();
    private FileExporter _exporter = new FileExporter();

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Digital Cookbook ===");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View All Recipes");
            Console.WriteLine("3. Search Recipes");
            Console.WriteLine("4. Edit Recipe");
            Console.WriteLine("5. Delete Recipe");
            Console.WriteLine("6. Scale Recipe");
            Console.WriteLine("7. Sort Recipes");
            Console.WriteLine("8. Favorites");
            Console.WriteLine("9. Export Recipe");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _manager.AddRecipe();
                    break;

                case "2":
                    _manager.ViewRecipes();
                    break;

                case "3":
                    SearchMenu();
                    break;

                case "4":
                    _manager.EditRecipe();
                    break;

                case "5":
                    _manager.DeleteRecipe();
                    break;

                case "6":
                    _manager.ScaleRecipe();
                    break;

                case "7":
                    _manager.SortRecipes();
                    break;

                case "8":
                    FavoritesMenu();
                    break;

                case "9":
                    ExportRecipeMenu();
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Bro that option ain't real. Try again.");
                    break;
            }
        }
    }

    private void SearchMenu()
    {
        Console.WriteLine("\nSearch by:");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Ingredient");
        Console.Write("Choose: ");

        string option = Console.ReadLine();

        if (option == "1") _manager.SearchByTitle();
        else if (option == "2") _manager.SearchByIngredient();
        else Console.WriteLine("Invalid search type dawg.");
    }

    private void FavoritesMenu()
    {
        Console.WriteLine("\n=== Favorites ===");
        _manager.ViewFavorites();
    }

    private void ExportRecipeMenu()
    {
        var recipes = _manager.GetAllRecipes();

        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes to export!");
            return;
        }

        Console.WriteLine("\nWhich recipe do you want to export?");
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Title}");
        }

        Console.Write("Choose a recipe number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= recipes.Count)
        {
            _exporter.Export(recipes[index - 1]);
        }
        else
        {
            Console.WriteLine("Invalid.");
        }
    }
}
