using System.Collections.Generic;
using System.Linq;

public class SearchEngine
{
    public List<Recipe> SearchByTitle(List<Recipe> recipes, string title)
    {
        return recipes
            .FindAll(r => r.Title.ToLower().Contains(title.ToLower()));
    }
}
