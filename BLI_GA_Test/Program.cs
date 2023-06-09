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
        private static BLI_Algorithm _bli;
        static void Main(string[] args)
        {
            _bli = new BLI_Algorithm();
            OnClick();
        }
        static void OnClick()
        {
            _bli.CalculateUsersSimilarity_WithAU();
            _bli.Run();
            PrintRecommendation(_bli.RecommendedIndividual);
        }
        static void PrintRecommendation(Individual individual)
        {
            Console.WriteLine("Recomended Movies:");
            foreach (var movieItem in individual.MovieList)
            {
                string output = string.Format("{0}",movieItem.MovieName);
                Console.WriteLine(output);
                Console.WriteLine("--------------------------");
            }

            Console.ReadKey();

        }
    }
}
