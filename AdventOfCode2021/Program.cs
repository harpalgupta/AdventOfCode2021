using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1();
            Day2();
        }
        private static void Day2()
        {
            //Day2Part1();
            Day2Part2();
        }

        private static void Day2Part1()
        {
            var day2Input = System.IO.File.ReadAllLines("Day2Input.txt");
            var horizontalTotal = 0;
            var depthTotal = 0;
            foreach (var input in day2Input)
            {
                var splitPos = input.Split(' ');
                if (splitPos[0] == "forward")
                {
                    horizontalTotal += int.Parse(splitPos[1]);
                }
                else if (splitPos[0] == "down")
                {
                    depthTotal += int.Parse(splitPos[1]);

                }
                else if (splitPos[0] == "up")
                {
                    depthTotal -= int.Parse(splitPos[1]);

                }

            }
            Console.WriteLine(horizontalTotal * depthTotal);
            Console.ReadKey();
        }

        private static void Day2Part2()
        {
            var day2Input = System.IO.File.ReadAllLines("Day2Input.txt");
            var horizontalTotal = 0;
            var depthTotal = 0;
            var aim = 0;
            foreach (var input in day2Input)
            {
                var splitPos = input.Split(' ');
                if (splitPos[0] == "forward")
                {
                    var properAim = Math.Abs(aim) == 0 ? 1 : Math.Abs(aim);
                    horizontalTotal += int.Parse(splitPos[1]) * properAim;
                    horizontalTotal += int.Parse(splitPos[1]);
                    Console.WriteLine($"{ int.Parse(splitPos[1])} * {properAim} ");
                }
                else if (splitPos[0] == "down")
                {
                    depthTotal += int.Parse(splitPos[1]);
                    aim -= int.Parse(splitPos[1]);


                }
                else if (splitPos[0] == "up")
                {
                    depthTotal -= int.Parse(splitPos[1]);
                    aim += int.Parse(splitPos[1]);

                }

            }
            Console.WriteLine($"{horizontalTotal} * {depthTotal}");
            Console.WriteLine(horizontalTotal * depthTotal);
            Console.ReadKey();
        }

        private static void Day1()
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
