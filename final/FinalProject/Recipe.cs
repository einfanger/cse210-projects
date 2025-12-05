using System;
using System.Collections.Generic;

public class Recipe
{
    public string Title { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<InstructionStep> Instructions { get; set; } = new List<InstructionStep>();
    public int CookTime { get; set; }
    public List<string> Tags { get; set; } = new List<string>();
    public bool IsFavorite { get; set; }

    public Recipe(string title)
    {
        Title = title;
    }

    public void AddIngredient(Ingredient ing) { }

    public void AddInstruction(InstructionStep step) { }

    public void ScaleRecipe(double factor) { }

    public void Display()
    {
        Console.WriteLine($"Recipe: {Title}");
    }
}
