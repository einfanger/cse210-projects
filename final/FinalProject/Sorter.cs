using System;
using System.Collections.Generic;
using System.Linq;

public class Sorter
{
    public List<Recipe> SortAlphabetically(List<Recipe> recipes)
    {
        return recipes.OrderBy(r => r.Title).ToList();
    }
}
