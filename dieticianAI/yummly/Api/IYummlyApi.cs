using Refit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yummly
{
    [Headers("X-Yummly-App-ID:c5aceb3f", "X-Yummly-App-Key:403ade941562861bd03bc510d178f8fb")]
    public interface IYummlyApi
    {
        [Get("/recipes?q={search}")]
        Task<SearchResult> SearchRecipe(string search);

        [Get("/recipe/{id}")]
        Task<Recipe> GetRecipe(string id);
    }
}
