using agent;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using yummly;

namespace dieticianAI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to intelliDiet. Please enter what you would like to do: \n");
            Console.WriteLine("a) Generate Meal Plan \n");
            Console.WriteLine("b) Get more recipes from Yummly \n");
            var response = Console.ReadLine();

            if(response == "a")
            {
                Console.WriteLine("In Production");
            }

            if(response == "b")
            {
                Console.WriteLine("What type of meals would you like to get?");
                var type = Console.ReadLine();
                await GetRecipes(type);
            }
        }

        static async Task GetRecipes(string search)
        {
            var yummlyService = new YummlyService();

            var recipes = await yummlyService.SearchRecipes(search);

            using (var db = new DietDbContext())
            {
                foreach (var item in recipes.Matches)
                {
                    // check if in database
                    if (db.FoodItems.Any(x => x.RecipeId == item.Id))
                    {
                        continue;
                    }

                    var recipe = await yummlyService.GetRecipe(item.Id);

                    var foodItem = new FoodItem
                    {
                        Name = item.RecipeName,
                        RecipeId = recipe.Id,
                        RawData = JsonConvert.SerializeObject(recipe),
                        Ingredients = JsonConvert.SerializeObject(item.Ingredients)
                    };

                    // save required nutrient values
                    var fatKCal = recipe.NutritionEstimates
                            .FirstOrDefault(x => string.Equals("FAT_KCAL", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (fatKCal != null)
                    {
                        foodItem.FAT_KCAL = fatKCal.Value;
                    }

                    var enerKCal = recipe.NutritionEstimates
                            .FirstOrDefault(x => string.Equals("ENERC_KCAL", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (enerKCal != null)
                    {
                        foodItem.ENERC_KCAL = enerKCal.Value;
                    }

                    var prot = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("PROCNT", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (prot != null)
                    {
                        foodItem.PROCNT = prot.Value;
                    }

                    var chol = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("CHOLE", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (chol != null)
                    {
                        foodItem.CHOLE = chol.Value;
                    }

                    var tCarb = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("CHOCDF", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (tCarb != null)
                    {
                        foodItem.CHOCDF = tCarb.Value;
                    }

                    var sugar = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("SUGAR", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (sugar != null)
                    {
                        foodItem.SUGAR = sugar.Value;
                    }

                    var fibre = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("FIBTG", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (fibre != null)
                    {
                        foodItem.FIBTG = fibre.Value;
                    }

                    var tFat = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("FAT", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (fatKCal != null)
                    {
                        foodItem.FAT = tFat.Value;
                    }

                    var satFat = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("FASAT", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (satFat != null)
                    {
                        foodItem.FASAT = satFat.Value;
                    }

                    var traFat = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("FATRN", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (traFat != null)
                    {
                        foodItem.FATRN = traFat.Value;
                    }

                    var water = recipe.NutritionEstimates
                           .FirstOrDefault(x => string.Equals("WATER", x.Attribute, StringComparison.OrdinalIgnoreCase));
                    if (water != null)
                    {
                        foodItem.WATER = water.Value;
                    }

                    await db.AddAsync(foodItem);

                }

                await db.SaveChangesAsync();
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
