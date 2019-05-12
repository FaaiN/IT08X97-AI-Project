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
    }
}
