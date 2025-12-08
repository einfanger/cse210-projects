using System;
using System.IO;

public class FileExporter
{
    public void Export(Recipe recipe)
    {
        string fileName = $"{recipe.Title}.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(recipe.Title);
            writer.WriteLine("\nIngredients:");
            foreach (var ing in recipe.Ingredients)
            {
                writer.WriteLine($"- {ing.Amount} {ing.Name}");
            }

            writer.WriteLine("\nInstructions:");
            foreach (var step in recipe.Instructions)
            {
                writer.WriteLine($"Step {step.StepNumber}: {step.Description}");
            }
        }

        Console.WriteLine($"Recipe exported to {fileName}");
    }
}
