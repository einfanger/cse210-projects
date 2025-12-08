using System;
using System.Collections.Generic;

public class Recipe
{
    public string Title { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<InstructionStep> Steps { get; set; } = new List<InstructionStep>();
    public int CookTime { get; set; }
    public bool Favorite { get; set; }

    public Recipe(string title)
    {
        Title = title;
    }

    public void Display()
    {
        Console.WriteLine($"\n--- {Title} ---");
        Console.WriteLine($"Cook Time: {CookTime} minutes");

        Console.WriteLine("\nIngredients:");
        foreach (var ing in Ingredients)
        {
            Console.WriteLine($"- {ing.Amount} {ing.Unit} {ing.Name}");
        }

        Console.WriteLine("\nInstructions:");
        foreach (var step in Steps)
        {
            Console.WriteLine($"{step.StepNumber}. {step.Text}");
        }

        Console.WriteLine(Favorite ? "\n★ Favorited" : "");
    }
}
