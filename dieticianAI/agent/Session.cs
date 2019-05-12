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

        public void CalculateBMI(double height, double weight)
        {
            if (height > 0 && weight > 0) {
                this.BMI = weight / (height / 100 * height / 100);
            }
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
