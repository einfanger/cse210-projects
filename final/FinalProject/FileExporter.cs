using System;
using System.IO;

public class FileExporter
{
    private string folder;

    public FileExporter(string folderName)
    {
        folder = folderName;

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
    }

    public void Export(Recipe r)
    {
        string fileName = $"{folder}/{r.Title.Replace(" ", "_")}.txt";

        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.WriteLine($"Recipe: {r.Title}");
            sw.WriteLine($"Cook Time: {r.CookTime} minutes\n");

            sw.WriteLine("Ingredients:");
            foreach (var ing in r.Ingredients)
                sw.WriteLine($"- {ing.Amount} {ing.Unit} {ing.Name}");

            sw.WriteLine("\nInstructions:");
            foreach (var step in r.Steps)
                sw.WriteLine($"{step.StepNumber}. {step.Text}");

            if (r.Favorite)
                sw.WriteLine("\n★ Favorited");
        }
    }
}
