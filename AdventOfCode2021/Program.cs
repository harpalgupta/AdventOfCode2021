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
            //Day2();
            Day3();

        }
        private static void Day2()
        {
            //Day2Part1();
            //Day2Part2();



        }

        private static void Day3()
        {
            var day3Input = System.IO.File.ReadAllLines("Day3Input.txt");

            var lines = new List<int[]>();

            string gammaRate = string.Empty;

            foreach (var input in day3Input)
            {
                lines.Add(input.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray());
            }
            var countOf1Bits = new int[5];

            foreach (var line in lines)
            {
                var pos = 0;
                foreach (var bit in line)
                {
                    countOf1Bits[pos] += bit;
                    
                    pos++;

                }
               

            }

            foreach (var item in countOf1Bits)
            {
                if (item > lines.Count / 2)
                {
                    gammaRate.Append('1');
                }
                else
                {
                    gammaRate.Append('0');
                }

            }
            Console.WriteLine(gammaRate);

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
                    horizontalTotal += int.Parse(splitPos[1]);
                    if (aim != 0)
                    {
                        depthTotal += int.Parse(splitPos[1]) * aim;
                    }
                }
                else if (splitPos[0] == "down")
                {
                    aim += int.Parse(splitPos[1]);


                }
                else if (splitPos[0] == "up")
                {
                    aim -= int.Parse(splitPos[1]);

                }
                Console.WriteLine($"aim:{aim}");


            }
            Console.WriteLine($"{horizontalTotal} * {depthTotal}");
            Console.WriteLine(horizontalTotal * depthTotal);
            Console.ReadKey();
        }

        private static void Day1()
        {
            var day1Input = System.IO.File.ReadAllLines("Day1Input.txt");
            var sonarInputs = day1Input.Select(d => int.Parse(d));
            Day1Part1(sonarInputs.ToArray());
            Day1Part2(sonarInputs.ToArray());
        }

        private static void Day1Part1(int[] sonarInputs)
        {

            CountIncreasesAndDecreasesInInput(sonarInputs);

            Console.ReadKey();
        }
        private static void Day1Part2(int[] sonarInputs)
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

            Console.ReadKey();
        }

        private static void CountIncreasesAndDecreasesInInput(int[] sonarInputs)
        {
            var index = 0;
            var countOfIncreases = 0;
            var countOfDecreases = 0;

            foreach (var sonarInput in sonarInputs)
            {
                if (index != 0)
                {
                    if (sonarInput < sonarInputs[index - 1])
                    {
                        countOfDecreases++;
                    }
                    else if (sonarInput > sonarInputs[index - 1])
                    {
                        countOfIncreases++;
                    }
                }
                index++;

            }
            Console.WriteLine($"number of decreases: {countOfDecreases} number of increases: {countOfIncreases}");
        }
    }
}
