using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace yummly
{
   public class YummlyService
    {
        private readonly string YUMMLY_API_URL = "http://api.yummly.com/v1/api";
        private readonly IYummlyApi yummlyApi;

        public YummlyService()
        {
            yummlyApi = RestService.For<IYummlyApi>(YUMMLY_API_URL);
        }

        public async Task<SearchResult> SearchRecipes(string term)
        {
            var results = await yummlyApi.SearchRecipe(term);

            return results;
        }

        public async Task<Recipe> GetRecipe(string term)
        {
            var recipe = await yummlyApi.GetRecipe(term);

            return recipe;
        }
    }
}
