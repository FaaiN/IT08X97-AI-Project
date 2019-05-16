using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class Individual
    {
        FoodItem item;
        public double Fitness { get; set; }
        public double[] Genes { get; set; } // is this even necessary
        public int GeneLength { get; set; }

        public Individual()
        {
            FoodItem item = new FoodItem();
            // initialise food item

        }

        // fitness based on fitness for each gene in individual
        // Individual == FoodItem
        // gene == nutrient
        // fitness measured in calories
        public double CalcFitness()
        {
            return item.CalcTotalFitness();
        }

       
    }
}
