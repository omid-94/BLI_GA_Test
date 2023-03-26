﻿using BLI_GA_Test.Classes;
using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Classes.Genetic_Operators;
using BLI_GA_Test.Classes.Genetic_Operators.Fitness;
using BLI_GA_Test.Classes.Semantic_Correlation;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configs = Configs.GetInstance().ConfigValues;

            var dataHolder = DataHolder.GetInstance();
            dataHolder.Users_With_Similarity = new UserSimilarity().Compute();

            var population = new PopulationGenerator().Generate();
            foreach (var ind in population)
            {
                ind.Fitness =  new IndividualFitness(ind).Compute();
            }
            //Sort population according to Semantic-Correlation by "Tag,Genre"
            population = population
                .OrderByDescending(ind => ind.Fitness)
                .ToList();

            int topBestIndNumber = (int)(configs.PopulationSize * 0.10);
            //Top 10% best individuals according to Semantic-Correlation by "Tag,Genre"
            var newGeneration = population
                .Take(topBestIndNumber)
                .ToList();

            var geneticOperations = new GeneticOperations(ref population, topBestIndNumber);
            geneticOperations.Apply();
            newGeneration = newGeneration.Union(geneticOperations.GetNewGeneration()).ToList();
        }
    }
}
