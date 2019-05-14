using System;
using System.Collections.Generic;
using System.Text;

namespace agent
{
    class Population
    {
        public int PopulationSize { get; set; }
        public Individual[] Individuals { get; set; } // makes up population
        public int IndexFittest { get; set; } // index of fittest individual
        public double FitnessValue { get; set; } // value of fitness for Fittest Individual

        public void initialise(int Size)
        {
            // create array of individuals of length Size
            Individuals = new Individual[Size];
            for (int i = 0; i < Individuals.Length; i++)
            {
                // initialise each Individual element 
                Individuals[i] = new Individual();
            }
        }

        public void CalcFitness()
        {
            // Calculate fitness of each individual
            for (int i = 0; i < Individuals.Length; i++)
            {
                Individuals[i].CalcFitness();
            }
            // getFittest
            getFittest();
        }

        // Finds the fittest individual
        private Individual getFittest()
        {
            double max = 1;
            IndexFittest = 0;
            for (int i = 0; i < Individuals.Length; i++)
            {
                if (max <= Individuals[i].Fitness)
                {
                    max = Individuals[i].Fitness;
                    IndexFittest = i;
                }
            }
            // gets actual individual with bext fitness
            FitnessValue = Individuals[IndexFittest].Fitness;
            return Individuals[IndexFittest];
        }
    }
}
