using agent;
using agent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dieticianAI
{
    public class GeneticAgent
    {
        private Population MealPopulation;

        public Individual Best { get; set; }
        public Individual SecondBest { get; set; }
        public Individual Child { get; set; }

        public GeneticAgent(Population population)
        {
            MealPopulation = population;

            Best = new Individual();
            SecondBest = new Individual();

            Child = new Individual();
        }

        public void FindBest(double caloricNeeds, double bmi)
        {
            // calculate inital fitness
            MealPopulation.CalcFitness();

            // loop till best found
            var run = 0;
            var maxVariations = 1000;

            // adjust for weight status
            var caloricAdjustment = (caloricNeeds * 0.1);
            if (bmi >= 25) { caloricAdjustment = -(caloricNeeds * 0.2); }
            if (bmi <= 18.5) { caloricAdjustment = (caloricNeeds * 0.2); }

            while (MealPopulation.FitnessValue < (caloricNeeds + caloricAdjustment) && run < maxVariations)
            {
                Console.WriteLine("Testing variation: " + ++run + "/1000");
                
                // get Best 2 fittest
                Best = MealPopulation.GetFittest();
                SecondBest = MealPopulation.GetSecondFittest();

                // add fittest offspring to population
                var child = GenerateOffspring();
                MealPopulation.AddIndividual(child);

                // calculate new fitness
                MealPopulation.CalcFitness();
            }
        }

        private Individual GenerateOffspring()
        {
            var rnd = new Random();

            // base offspring on previous generation
            // so it essentially evolves towards optimal
            var child = Individual.Clone(Child);

            // crossbreed
            Crossbreed(child);

            // mutate - chance < 7%
            if (rnd.Next(0, 100) < 7)
            {
                Mutate(child);
            }

            return Child = child;
        }

        private void Mutate(Individual child)
        {
            var rnd = new Random();
            var mutation = rnd.Next(0, child.Genes.Length);
           
            using (var db = new DietDbContext())
            {
                var totalDataSet = db.FoodItems.Count();

                //todo: enhance per category e.g. breakfast, snack, lunch, supper
                var id = rnd.Next(1, totalDataSet);
                var recipe = db.FoodItems.Find(id);
                if (recipe == null) { Console.WriteLine("Recipe null"); }

                // if we haven't used this variation already, add it to the set
                if (!child.Genes.Any(g => string.Equals(g.Name, recipe.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    child.Genes[mutation].Name = recipe.Name;
                    child.Genes[mutation].Fitness = recipe.CalcTotalFitness();

                    //Console.WriteLine("Mutation Occurred. Individual added to population");
                    return;
                }

                // we have used it, try another variation
                Mutate(child);
            }
        }

        private void Crossbreed(Individual child)
        {
            var rnd = new Random();
            var swopIndex = rnd.Next(0, child.Genes.Length);

            //todo: enhance per category e.g. breakfast, snack, lunch, supper
            for (int i = 0; i < swopIndex; i++)
            {
                //todo: check for duplicate genes
                child.Genes[i] = Gene.Clone(Best.Genes[i]);
            }

            //todo: enhance per category e.g. breakfast, snack, lunch, supper
            for (int i = swopIndex; i < child.Genes.Length; i++)
            {
                //todo: check for duplicate genes
                child.Genes[i] = Gene.Clone(SecondBest.Genes[i]);
            }
        }
    }
}
