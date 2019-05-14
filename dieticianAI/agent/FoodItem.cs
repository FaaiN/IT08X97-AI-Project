using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class FoodItem
    {
        public string Name { get; set; }
        // Calories from fat
        public double FAT_KCAL { get; set; }
        // Calories
        public double ENERC_KCAL { get; set; }
        // Protein
        public double PROCNT { get; set; }
        // Cholesterol
        public double CHOLE { get; set; }
        // Total Carbohydrates
        public double CHOCDF { get; set; }
        // Sugars
        public double SUGAR { get; set; }
        // Dietary Fibre
        public double FIBTG { get; set; }
        // Total Fat
        public double FAT { get; set; }
        // Saturated Fat
        public double FASAT { get; set; }
        // Trans Fat
        public double FATRN { get; set; }
        // Water
        public double WATER { get; set; }
    }
}
