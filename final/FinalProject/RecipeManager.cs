using System;
using System.Collections.Generic;
using System.IO;

public class RecipeManager
{
    private List<Recipe> recipes = new List<Recipe>();
    private SearchEngine searcher = new SearchEngine();
    private FileExporter exporter = new FileExporter("recipes");

    public void AddRecipe()
    {
        Console.Write("Enter recipe title: ");
        string title = Console.ReadLine();

        Recipe r = new Recipe(title);

        Console.Write("Cook time (minutes): ");
        r.CookTime = int.Parse(Console.ReadLine());

        Console.WriteLine("\nAdd ingredients (type 'done' to finish):");

        while (true)
        {
            Console.Write("Ingredient name: ");
            string name = Console.ReadLine();

            if (name.ToLower() == "done")
                break;

            Console.Write("Amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.Write("Unit: ");
            string unit = Console.ReadLine();

            r.Ingredients.Add(new Ingredient(name, amount, unit));
        }

        Console.WriteLine("\nAdd instruction steps (type 'done' to finish):");
        int stepNum = 1;

        while (true)
        {
            Console.Write($"Step {stepNum}: ");
            string stepText = Console.ReadLine();

            if (stepText.ToLower() == "done")
                break;

            r.Steps.Add(new InstructionStep(stepNum, stepText));
            stepNum++;
        }

        recipes.Add(r);
        Console.WriteLine("\nRecipe added successfully!");
    }

    public void DisplayAll()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes yet, king.");
            return;
        }

        foreach (var r in recipes)
        {
            r.Display();
        }
    }

    public void Search()
    {
        Console.Write("Search by title: ");
        string term = Console.ReadLine();

        var results = searcher.SearchByTitle(recipes, term);

        if (results.Count == 0)
        {
            Console.WriteLine("No matches found.");
            return;
        }

        foreach (var r in results)
        {
            r.Display();
        }
    }

    public void Delete()
    {
        Console.Write("Enter the title of the recipe to delete: ");
        string title = Console.ReadLine();

        var r = recipes.Find(x => x.Title.ToLower() == title.ToLower());

        if (r == null)
        {
            Console.WriteLine("Recipe not found.");
            return;
        }

        recipes.Remove(r);
        Console.WriteLine("Recipe deleted.");
    }

    public void MarkFavorite()
    {
        Console.Write("Enter recipe title to favorite: ");
        string title = Console.ReadLine();

        var r = recipes.Find(x => x.Title.ToLower() == title.ToLower());

        if (r == null)
        {
            Console.WriteLine("Recipe not found.");
            return;
        }

        r.Favorite = true;
        Console.WriteLine("Recipe favorited!");
    }

    public void ShowFavorites()
    {
        var favs = recipes.FindAll(r => r.Favorite);

        if (favs.Count == 0)
        {
            Console.WriteLine("No favorites yet.");
            return;
        }

        foreach (var r in favs)
        {
            r.Display();
        }
    }

    public void ExportRecipe()
    {
        Console.Write("Enter recipe title to export: ");
        string name = Console.ReadLine();

        var r = recipes.Find(x => x.Title.ToLower() == name.ToLower());

        if (r == null)
        {
            Console.WriteLine("Not found.");
            return;
        }

        exporter.Export(r);
        Console.WriteLine("Recipe exported to /recipes folder!");
    }
}
