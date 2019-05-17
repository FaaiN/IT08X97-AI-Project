using System;
using System.Collections.Generic;
using System.Text;

namespace agent.Models
{
    public class Gene
    {
        public string Name { get; set; }
        public double Fitness { get; set; }

        public static Gene Clone(Gene gene)
        {
            return new Gene
            {
                Name = gene.Name,
                Fitness = gene.Fitness
            };
        }
    }
}
