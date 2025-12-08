using System;

public class Ingredient
{
    public string Name { get; set; }
    public string Amount { get; set; }

    public override string ToString()
    {
        return $"{Amount} {Name}";
    }
}
