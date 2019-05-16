using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    public enum MealType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack
    }
    class Meal
    {
        public int Id { get; set; }
        public MealType Type { get; set; }
        public DateTime Time { get; set; }

        public Meal() { }

    }
}
