using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class Individual
    {
        public double Fitness { get; set; }
        public double[] Genes { get; set; }
        public int GeneLength { get; set; }

        public Individual()
        {

        }

        // fitness based on fitness for each gene in individual
        // Individual == FoodItem
        // gene == nutrient
        public double CalcFitness()
        {
            return 0.0;
        }
    }
}
