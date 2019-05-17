using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class Session
    {
        public int Id { get; set; }
        // Would this not be under user, each session doesn't have a new set of allergies
        // Unless we make it a static
        // public Array Allergies { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        private ICollection<Meal> EatingHabits;

        public Session() { }

        public void AddAllergy(string Allergy)
        {
            //Allergies.Add(Allergy);
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
