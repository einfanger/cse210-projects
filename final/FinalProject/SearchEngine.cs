using System;
using System.Collections.Generic;
using System.Linq;

public class SearchEngine
{
    public List<Recipe> SearchByTitle(List<Recipe> recipes, string query)
    {
        return recipes.Where(r => r.Title.ToLower().Contains(query.ToLower())).ToList();
    }

    public List<Recipe> SearchByIngredient(List<Recipe> recipes, string ingredient)
    {
        return recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient.ToLower()))).ToList();
    }
}
