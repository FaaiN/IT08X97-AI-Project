using agent.Models;

namespace agent
{
    public class Individual
    {
        public double Fitness { get; set; }
        public Gene[] Genes { get; set; }
        static int GeneLength { get; set; } = 4;

        public Individual()
        {
            Genes = new Gene[GeneLength];
            for(var i = 0; i < GeneLength; i++)
            {
                Genes[i] = new Gene();
            }
        }

        // fitness based on fitness for each gene in individual
        // Individual == FoodItem
        // gene == nutrient
        // fitness measured in calories
        public double CalcFitness()
        {
            Fitness = 0.0;
            for (var i = 0; i < GeneLength-1; i++)
            {
                Fitness += Genes[i].Fitness;
            }
            return Fitness;
        }

       
    }
}
