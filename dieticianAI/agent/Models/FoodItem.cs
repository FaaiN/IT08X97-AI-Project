using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string RecipeId { get; set; }
        public string Name { get; set; }
        // All data of recipe
        public string RawData { get; set; }
        // All ingredients of recipe
        public string Ingredients { get; set; }
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

        // to calculate fitness of fooditem
        const int CALPERGPROTEIN = 4;
        const int CALPERGCARBS = 4;
        const int CALPERGFAT = 9;
        const int CALPERGSUGAR = 4;

        public double CalcTotalFitness()
        {
            double fitness = 0;
            fitness = (PROCNT * CALPERGPROTEIN) + (CHOCDF * CALPERGCARBS) + (FAT * CALPERGFAT) + (SUGAR * CALPERGSUGAR);
            return fitness;
        }
    }
}
