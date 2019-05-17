using agent.Models;
using System.Collections.Generic;
using System.Linq;

namespace agent
{
    public class Individual
    {
        static int GeneLength { get; set; } = 4;

        public double Fitness { get; set; }
        public Gene[] Genes { get; set; }

        public Individual()
        {
            Genes = new Gene[GeneLength];
            for (var i = 0; i < GeneLength; i++)
            {
                Genes[i] = new Gene();
            }
        }

        // fitness based on fitness for each gene in individual
        // Individual == FoodItem
        // gene == nutrient
        // fitness measured in calories
        public void CalcFitness()
        {
             Fitness = Genes.Sum(g => g.Fitness);
        }

        public static Individual Clone(Individual individual)
        {
            var clone = new Individual {
                Fitness=individual.Fitness
            };

            for (int i = 0; i < individual.Genes.Length; i++)
            {
                clone.Genes[i].Name = individual.Genes[i].Name;
                clone.Genes[i].Fitness = individual.Genes[i].Fitness;
            }

            return clone;
        }

    }
}
