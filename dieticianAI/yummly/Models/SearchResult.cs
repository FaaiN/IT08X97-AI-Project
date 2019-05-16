using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace yummly
{
    public class SearchResult
    {
        public SearchResult()
        {
            Matches = Enumerable.Empty<Recipe>().ToList();
        }

        public ICollection<Recipe> Matches { get; set; }

    }

    public class Recipe
    {
        public Recipe()
        {
            Ingredients = Enumerable.Empty<string>().ToList();

            NutritionEstimates = Enumerable.Empty<NutritionEstimate>().ToList();
        }

        public string Id { get; set; }

        public string RecipeName { get; set; }

        public ICollection<string> Ingredients { get; set; }

        public ICollection<NutritionEstimate> NutritionEstimates { get; set; }
    }

    public class NutritionEstimate
    {
        public string Attribute { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public NutritionUnit Unit { get; set; }

    }

    public class NutritionUnit
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }
    }
}
