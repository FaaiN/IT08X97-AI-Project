using System;
using System.Collections.Generic;
using System.Linq;

namespace agent
{
    public class Population
    {
        public int PopulationSize { get; set; }
        public ICollection<Individual> Individuals { get; set; } // makes up population
        public int IndexFirst { get; set; } // index of fittest individual
        public int IndexSecond { get; set; } // index of second fittest individual
        public double FitnessValue { get; set; } // value of fitness for Fittest Individual

        public Population()
        {
            Individuals = Enumerable.Empty<Individual>().ToList(); ;
        }

        public void AddIndividual(Individual individual)
        {
            Individuals.Add(individual);           
        }

        public void CalcFitness()
        {
            // Calculate fitness of each individual
            foreach(var individual in Individuals)
            {
                individual.CalcFitness();
            }
        }

        // Finds the fittest individual
        public Individual GetFittest()
        {
            double first = Individuals.First().Fitness;
            IndexFirst = 0;
            for (int i = 0; i < Individuals.Count; i++)
            {
                if (first <= Individuals.ElementAt(i).Fitness)
                {
                    first = Individuals.ElementAt(i).Fitness;
                    IndexFirst = i;
                }
            }
            FitnessValue = Individuals.ElementAt(IndexFirst).Fitness;
            return Individuals.ElementAt(IndexFirst);
        }

        public Individual GetSecondFittest()
        {
            IndexSecond = 0;
            for (int i = 0; i < Individuals.Count; i++)
            {
                if (Individuals.ElementAt(i).Fitness > Individuals.ElementAt(IndexFirst).Fitness)
                {
                    IndexSecond = IndexFirst;
                    IndexFirst = i;
                }
                else if (Individuals.ElementAt(i).Fitness > Individuals.ElementAt(IndexSecond).Fitness)
                {
                    IndexSecond = i;
                }
            }
            return Individuals.ElementAt(IndexSecond);
        }

        //public Individual underweightFittest(double CaloricNeeds)
        //{
        //    double first = Individuals.First().Fitness;
        //    IndexFirst = 0;
        //    for (int i = 0; i < Individuals.Count; i++)
        //    {
        //        if (first <= Individuals.ElementAt(i).Fitness)
        //        {
        //            first = Individuals.ElementAt(i).Fitness;
        //            IndexFirst = i;
        //        }
        //    }
        //    FitnessValue = Individuals.ElementAt(IndexFirst).Fitness;
        //    if (FitnessValue > CaloricNeeds)
        //    {
        //        // gets actual individual with best fitness
        //        return Individuals.ElementAt(IndexFirst);
        //    }
        //    return null;
        //}
        //public Individual overweightFittest(double CaloricNeeds)
        //{
        //    double max = Individuals.First().Fitness;
        //    IndexFittest = 0;
        //    for (int i = 0; i < Individuals.Count; i++)
        //    {
        //        if (max <= Individuals.ElementAt(i).Fitness)
        //        {
        //            max = Individuals.ElementAt(i).Fitness;
        //            IndexFittest = i;
        //        }
        //    }
        //    FitnessValue = Individuals.ElementAt(IndexFittest).Fitness;
        //    if (FitnessValue > CaloricNeeds)
        //    {
        //        // gets actual individual with best fitness
        //        return Individuals.ElementAt(IndexFittest);
        //    }
        //    return null;
        //}

    }
}
