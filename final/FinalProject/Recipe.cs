using System;
using System.Collections.Generic;

public class Recipe
{
    public string Title { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<InstructionStep> Instructions { get; set; } = new List<InstructionStep>();

    public override string ToString()
    {
        string ingStr = string.Join(", ", Ingredients);
        string steps = string.Join("\n", Instructions);
        return $"Title: {Title}\nIngredients: {ingStr}\nInstructions:\n{steps}";
    }
}
