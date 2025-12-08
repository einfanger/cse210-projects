using System;
using System.Collections.Generic;
using System.Linq;

public class RecipeManager
{
    private List<Recipe> _recipes = new List<Recipe>();
    private List<Recipe> _favorites = new List<Recipe>();

    public void AddRecipe()
    {
        Console.Write("Enter recipe title: ");
        string title = Console.ReadLine();

        List<Ingredient> ingredients = new List<Ingredient>();
        Console.WriteLine("Add ingredients (type 'done' to finish):");
        while (true)
        {
            Console.Write("Ingredient name: ");
            string name = Console.ReadLine();
            if (name.ToLower() == "done") break;

            Console.Write("Amount: ");
            string amount = Console.ReadLine();

            ingredients.Add(new Ingredient { Name = name, Amount = amount });
        }

        List<InstructionStep> steps = new List<InstructionStep>();
        Console.WriteLine("Add instruction steps (type 'done' to finish):");
        int stepNum = 1;
        while (true)
        {
            Console.Write($"Step {stepNum}: ");
            string desc = Console.ReadLine();
            if (desc.ToLower() == "done") break;
            steps.Add(new InstructionStep { StepNumber = stepNum, Description = desc });
            stepNum++;
        }

        _recipes.Add(new Recipe { Title = title, Ingredients = ingredients, Instructions = steps });
        Console.WriteLine($"Recipe '{title}' added!");
    }

    public void ViewRecipes()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes yet.");
            return;
        }

        Console.WriteLine("\n=== All Recipes ===");
        for (int i = 0; i < _recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_recipes[i].Title}");
        }
    }

    public void SearchByTitle()
    {
        Console.Write("Enter title to search: ");
        string query = Console.ReadLine().ToLower();
        var results = _recipes.Where(r => r.Title.ToLower().Contains(query)).ToList();
        DisplaySearchResults(results);
    }

    public void SearchByIngredient()
    {
        Console.Write("Enter ingredient to search: ");
        string query = Console.ReadLine().ToLower();
        var results = _recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(query))).ToList();
        DisplaySearchResults(results);
    }

    private void DisplaySearchResults(List<Recipe> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }

        Console.WriteLine("\nSearch results:");
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {results[i].Title}");
        }
    }

    public void EditRecipe()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes to edit.");
            return;
        }

        ViewRecipes();
        Console.Write("Enter recipe number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _recipes.Count)
        {
            Recipe recipe = _recipes[index - 1];
            Console.Write($"New title (press enter to keep '{recipe.Title}'): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle)) recipe.Title = newTitle;

            // Edit ingredients
            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                Console.Write($"Ingredient {i + 1} name (current: {recipe.Ingredients[i].Name}): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) recipe.Ingredients[i].Name = name;

                Console.Write($"Ingredient {i + 1} amount (current: {recipe.Ingredients[i].Amount}): ");
                string amount = Console.ReadLine();
                if (!string.IsNullOrEmpty(amount)) recipe.Ingredients[i].Amount = amount;
            }

            // Edit instructions
            foreach (var step in recipe.Instructions)
            {
                Console.Write($"Step {step.StepNumber} (current: {step.Description}): ");
                string desc = Console.ReadLine();
                if (!string.IsNullOrEmpty(desc)) step.Description = desc;
            }

            Console.WriteLine("Recipe updated!");
        }
        else
        {
            Console.WriteLine("Invalid recipe number.");
        }
    }

    public void DeleteRecipe()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes to delete.");
            return;
        }

        ViewRecipes();
        Console.Write("Enter recipe number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _recipes.Count)
        {
            Recipe removed = _recipes[index - 1];
            _recipes.RemoveAt(index - 1);
            Console.WriteLine($"Recipe '{removed.Title}' deleted!");
        }
        else
        {
            Console.WriteLine("Invalid recipe number.");
        }
    }

    public void ScaleRecipe()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes to scale.");
            return;
        }

        ViewRecipes();
        Console.Write("Enter recipe number to scale: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _recipes.Count)
        {
            Recipe recipe = _recipes[index - 1];
            Console.Write("Enter scale factor: ");
            if (double.TryParse(Console.ReadLine(), out double factor))
            {
                foreach (var ing in recipe.Ingredients)
                {
                    if (double.TryParse(ing.Amount, out double amt))
                        ing.Amount = (amt * factor).ToString();
                }
                Console.WriteLine("Recipe scaled!");
            }
            else Console.WriteLine("Invalid factor.");
        }
        else Console.WriteLine("Invalid recipe number.");
    }

    public void SortRecipes()
    {
        _recipes = _recipes.OrderBy(r => r.Title).ToList();
        Console.WriteLine("Recipes sorted alphabetically!");
    }

    public void ViewFavorites()
    {
        if (_favorites.Count == 0)
        {
            Console.WriteLine("No favorite recipes.");
            return;
        }

        Console.WriteLine("\n=== Favorite Recipes ===");
        for (int i = 0; i < _favorites.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_favorites[i].Title}");
        }
    }

    public List<Recipe> GetAllRecipes()
    {
        return _recipes;
    }

    public void ToggleFavorite(Recipe recipe)
    {
        if (_favorites.Contains(recipe)) _favorites.Remove(recipe);
        else _favorites.Add(recipe);
    }
}
