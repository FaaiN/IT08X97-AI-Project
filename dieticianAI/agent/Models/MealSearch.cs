using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class MealSearch
    {
        // Current State: BMI
        // Goal: Weight Goal
        // Constraints: Allergies, User- Satisfaction, Meal-Goal Success 
        // Possible Constraint: BMI (Should maintain health)
        

        // Genetic Algorithm?
        //      population: Meals that fit constraints/partial constraints?
        //      Fitness function: Some way of assessing relevance (fitness) of meal
        //                  - does meal align with recommended meal proportiions/composition for that bmi and purpose?

        // Information Gathering Agent(percept) returns (action)
        // integrate percept into decision network D
        // j - value that maximizes VPI(Ej)/Cost(Ej)
        // if VPI > Cost
        //      return REQUEST(Ej)
        // else return best action from D

        public string FitnessFunction()
        {
            // does meal match BMI requirements
            // does meal satisfy user
            // does meal achieve goal
            return "";
        }

        // Get list of meals that match user preference
        public string GetMeals(string constraints)
        {
            // call to yummly to get around 50 recipes
            // return recipes
            return "";
        }

        // Genetic search to find best meal (Population Length == 100)
        public string BestMeal(string[] meals)
        {
            string[] newMeals;
            bool found = false;
            do
            {
                // loop through population
                for( int i = 0; i < meals.Length; i++)
                {
                    // randomly select two parent meals
                    string mealP1 = RandomSelect(meals, "");
                };
                // stop search - meal is found
                found = true;
            } while (found);
            // loop through meals
            return "";
        }

        public string RandomSelect(string[] meals, string fitness)
        {
            return "";
        }
    }
}
