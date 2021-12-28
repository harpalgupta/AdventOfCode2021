using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1();
            //Day2();
            //Day3();
            Day4();

            Console.ReadKey();
        }
        private static void Day2()
        {
            //Day2Part1();
            //Day2Part2();



        }

        private static void Day3()
        {
            Day3Part1and2();
        }

        private static int GetCommonBit(IEnumerable<int> bits, bool mostCommonBit)
        {
            var countOfBits = bits.Count();
            var countOfZeros = bits.Count(b => b == 0);
            var countOfOnes = bits.Count(b => b == 1);

            if (countOfOnes > countOfZeros)
            {
                if (mostCommonBit)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (countOfZeros > countOfOnes)
            {
                if (mostCommonBit)
                {
                    return 0;
                }
                else return 1;
            }
            else
            {
                if (mostCommonBit)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }

        }
        private static void Day3Part1and2()
        {
            var day3Input = System.IO.File.ReadAllLines("Day3Input.txt");

            var lines = new List<int[]>();

            var gammaRate = new StringBuilder();
            var epsilonRate = new StringBuilder();

            foreach (var input in day3Input)
            {
                lines.Add(input.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray());
            }
            var lengthOfBitsInLine = lines.First().Length;

            //Part 1
            for (int position = 0; position < lengthOfBitsInLine; position++)
            {
                var collectionOfBits = new List<int>();
                foreach (var line in lines)
                {
                    collectionOfBits.Add(line[position]);
                }
                var mostCommonBit = GetCommonBit(collectionOfBits, true);
                var leastCommonBit = mostCommonBit == 1 ? 0 : 1;
                gammaRate.Append(mostCommonBit);
                epsilonRate.Append(leastCommonBit);
            }

            Console.WriteLine(Convert.ToInt32(gammaRate.ToString(), 2) * Convert.ToInt32(epsilonRate.ToString(), 2));
            
            //Part2
            var keepOxygenList = lines;
            var keepCo2List = lines;

            for (int position = 0; position < lengthOfBitsInLine; position++)
            {

                var mostCommonBit = GetCommonBit(keepOxygenList.Select(l => l[position]).ToList(), true);
                var leastCommonBit = GetCommonBit(keepCo2List.Select(l => l[position]).ToList(), false);
                if (keepOxygenList.Count > 1)
                {
                    keepOxygenList = keepOxygenList?
                    .Where((b) => b[position] == mostCommonBit)
                    .ToList();
                }
                if (keepCo2List.Count > 1)
                {
                    keepCo2List = keepCo2List?
                        .Where((b) => b[position] == leastCommonBit)
                        .ToList();
                }
            }
            var oxygenBinaryString = string.Join("", keepOxygenList.First());
            var co2BinaryString = string.Join("", keepCo2List.First());
            var lifeSupportRating = Convert.ToInt32(oxygenBinaryString, 2) * Convert.ToInt32(co2BinaryString, 2);
            Console.WriteLine(lifeSupportRating);
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

        private static void Day4()
        {
            var bingoGrids = PopulateBingoGridsFromInput();

            foreach (var grid in bingoGrids)
            {

            }


        }

        private static List<List<string[]>> PopulateBingoGridsFromInput()
        {
            var day4Input = System.IO.File.ReadAllText("Day4Input.txt");
            var numbersRead = day4Input.Split("\r\n\r\n").First().Split(",");
            string pattern = @"(\r\n[\d|\s\d].+){5}";
            Regex rx = new Regex(pattern);

            var matchedGrids = rx.Matches(day4Input);
            var bingoGrids = new List<List<string[]>>();
            //populate/ format bingo grids
            foreach (var grid in matchedGrids)
            {
                var pattern1 = @"(?:\s)";
                var regex = new Regex(pattern1);
                var gridOfLines = new List<string[]>();
                var matchedGrid = (Match)grid;

                var gridAstext = matchedGrid.Value.Split("\\r\\n", StringSplitOptions.RemoveEmptyEntries).First();
                var gridOfLinesFormatted = gridAstext.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
                bingoGrids.Add(gridOfLinesFormatted.ToList());
            }

            return bingoGrids;
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
