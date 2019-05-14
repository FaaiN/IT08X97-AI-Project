using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class Session
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        // Would this not be under user, each session doesn't have a new set of allergies
        // Unless we make it a static
        // public Array Allergies { get; set; }
        public double GoalWeight { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        private ICollection<Meal> EatingHabits;

        public Session() { }

        public void AddAllergy(string Allergy)
        {
            //Allergies.Add(Allergy);
        }

        // BMI Calculation to find out if under/nomral/overweght
        public void CalculateBMI(double height, double weight)
        {
            if (height > 0 && weight > 0) {
                this.BMI = weight / (height * height);
            }
        }

        // Calculation to find out how calorie needs in meal
        public double CaloricNeeds(string Gender)
        {
            double gMultiplier = 1.0; // gender == male
            double fMultiplier = 1.0; // bmi = normal weight

            if (Gender == "Female") { gMultiplier = 0.9; }
            if (BMI < 18.5 ) { fMultiplier = 1.1; } else if (BMI > 25.0) { fMultiplier = 0.9; }

            return Weight * gMultiplier * 24 * fMultiplier;
        }

        // Create a new list of eating habits and adds a new entry
        private void CreateEatingHabit(Meal MealHabit)
        {
            EatingHabits = new List<Meal>();
            AddEatingHabit(MealHabit);
        }
        // Adds a new meal habit (entry) to the list of eating habits
        private void AddEatingHabit(Meal MealHabit)
        {
            EatingHabits.Add(MealHabit);
        }
        // Gets the list of eating habits
        public string GetEatingHabit()
        {
            return EatingHabits.ToString();
        }

        // Generate Meal Plan
    }
}
