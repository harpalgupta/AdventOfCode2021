using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var day1Input = System.IO.File.ReadAllLines("Day1Input.txt");
            var sonarInputs = day1Input.Select(d => int.Parse(d));
            Part1(sonarInputs.ToArray());
            Part2(sonarInputs.ToArray());
        }

        private static void Part1(int[] sonarInputs)
        {
           
            CountIncreasesAndDecreasesInInput(sonarInputs);

            Console.ReadKey();
        }
        private static void Part2(int[] sonarInputs)
        {
          

            var position = 0;
            var output = new List<int>();
            foreach (var input in sonarInputs)
            {
                    try
                    {
                    output.Add(input + sonarInputs[position + 1] + sonarInputs[position + 2]);
                    }
                    catch
                    {
                    //Catch out of range exception
                    }
                
                position++;

            }
            CountIncreasesAndDecreasesInInput(output.ToArray());



            

            //CountIncreasesAndDecreasesInInput(sonarInputs);

            Console.ReadKey();
        }

        private static void CountIncreasesAndDecreasesInInput(int[] sonarInputs)
        {
            var index = 0;
            var countOfIncreases = 0;
            var countOfDecreases = 0;

            foreach (var sonarInput in sonarInputs)
            {
                if (index == 0)
                {
                }
                else if (sonarInput < sonarInputs[index - 1])
                {
                    countOfDecreases++;
                }
                else if (sonarInput > sonarInputs[index - 1])
                {
                    countOfIncreases++;
                }
                index++;

            }
            Console.WriteLine($"number of decreases: {countOfDecreases} number of increases: {countOfIncreases}");
        }
    }
}
