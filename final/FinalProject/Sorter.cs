using System.Collections.Generic;
using System.Linq;

public class Sorter
{
    public List<Recipe> SortByCookTime(List<Recipe> recipes)
    {
        return recipes.OrderBy(r => r.CookTime).ToList();
    }

    public List<Recipe> SortAlpha(List<Recipe> recipes)
    {
        return recipes.OrderBy(r => r.Title).ToList();
    }
}
