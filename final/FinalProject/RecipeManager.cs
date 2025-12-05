using System;
using System.Collections.Generic;

public class RecipeManager
{
    private List<Recipe> recipes = new List<Recipe>();

    public void AddRecipe()
    {
        Console.WriteLine("Adding empty example recipe (placeholder).");
        recipes.Add(new Recipe("New Recipe"));
    }

    public void DeleteRecipe() { }

    public void EditRecipe() { }

    public void GetAllRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes added yet.");
            return;
        }

        foreach (var recipe in recipes)
        {
            recipe.Display();
        }
    }

    public void GetFavorites() { }
}
