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
            // Sys Home
            Console.WriteLine("Welcome to intelliDiet. Please enter what you would like to do: \n");
            Console.WriteLine("a) Generate Meal Plan \n");
            Console.WriteLine("b) Get more recipes from Yummly \n");
            var response = Console.ReadLine();

            if (response == "a")
            {
                // User info
                Console.WriteLine("Are you a male or female?");
                var gender = Console.ReadLine();
                Console.WriteLine("Please enter in your height (cm)");
                double height = Double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter in your weight (kg)");
                double weight = Double.Parse(Console.ReadLine());

                // create user
                var user = new User(gender, height, weight);

                // Calc bmi
                Console.WriteLine("Your BMI is: {0:F2}", user.CalculateBMI());
                Console.WriteLine(user.BmiResult());

                // Calc goal
                Console.WriteLine("Please enter in your goal weight");
                user.GoalWeight = Double.Parse(Console.ReadLine());
                var caloricNeeds = user.CaloricNeeds(gender);
                Console.WriteLine("Your Caloric Needs are: {0:F2}", caloricNeeds);

                // Get recipes and meal plans
                Console.WriteLine("\nGetting population.");
                var mealPop = GetRecipes();

                var dietAgent = new GeneticAgent(mealPop);

                // find best permutation
                dietAgent.FindBest(caloricNeeds);

                Console.WriteLine("Best meal set is:");
                Console.WriteLine(dietAgent.Best.Genes[0].Name + " ---- Calories: " + dietAgent.Best.Genes[0].Fitness);
                Console.WriteLine(dietAgent.Best.Genes[1].Name + " ---- Calories: " + dietAgent.Best.Genes[1].Fitness);
                Console.WriteLine(dietAgent.Best.Genes[2].Name + " ---- Calories: " + dietAgent.Best.Genes[2].Fitness);
                Console.WriteLine(dietAgent.Best.Genes[3].Name + " ---- Calories: " + dietAgent.Best.Genes[3].Fitness);

                Console.WriteLine("Total Calories: " + dietAgent.Best.Fitness);
                Console.WriteLine("Target Calories: " + caloricNeeds);

                Console.ReadKey();
            }

            if (response == "b")
            {
                Console.WriteLine("What type of meals would you like to get?");
                var type = Console.ReadLine();
                await AddRecipes(type);
            }
        }

        public static Population GetRecipes()
        {
            var rnd = new Random();
            var mealPop = new Population();

            using (var db = new DietDbContext())
            {
                var totalDataSet = db.FoodItems.Count();

                for (var j = 1; j < 11; j++)
                {
                    var mealIndividual = new Individual();

                    var i = 0;
                    while (i < mealIndividual.Genes.Length)
                    {
                        //todo: add categorisation for breakfast, snack, lunch, supper
                        int id = rnd.Next(1, totalDataSet);
                        var recipe = db.FoodItems.Find(id);
                        if (recipe == null) { Console.WriteLine("Recipe null"); }
                        if (mealIndividual.Genes.Any(g => string.Equals(g.Name, recipe.Name, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        mealIndividual.Genes[i].Name = recipe.Name;
                        mealIndividual.Genes[i].Fitness = recipe.CalcTotalFitness();

                        i++;
                    }

                    //todo: enhance meal set per category e.g. breakfast, snack, lunch, supper
                    mealPop.AddIndividual(mealIndividual);
                    Console.WriteLine("Meal set {0} added", j);
                }
            };

            Console.WriteLine("Population has been filled.");
            return mealPop;
        }

        static async Task AddRecipes(string search)
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
                    Console.WriteLine(item.RecipeName);
                }

                await db.SaveChangesAsync();
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
