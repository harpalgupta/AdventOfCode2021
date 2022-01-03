using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2021.Models;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main()
        {
            //Day1();
            //Day2();
            //Day3();
            //Day4();
            Day5();

            Console.ReadKey();
        }

        private static void Day5()
        {
            var day5Input = System.IO.File.ReadAllLines("Day5Input.txt");
            var grid = new List<GridPosition>();
            var dictionaryOfTotals = new Dictionary<string, int>();
            foreach (var line in day5Input)
            {
                var positions = line.Split(new[] { " -> " }, StringSplitOptions.None);
                var start = positions[0].Split(',');
                var end = positions[1].Split(',');
                var startPos= new GridPosition { X = int.Parse(start[0]), Y = int.Parse(start[1]) };
                var endPos = new GridPosition { X = int.Parse(end[0]), Y = int.Parse(end[1]) };
                var columnRange = false;
                var rowRange = false;

                if (startPos.X == endPos.X && startPos.Y != endPos.Y)
                {
                    columnRange = true;
                }

                if (startPos.Y == endPos.Y && startPos.X != endPos.X)
                {
                    rowRange = true;
                }

                if (rowRange)
                {
                    var beginning = startPos;
                    var ending = endPos;
                    if (startPos.X> endPos.X)
                    {
                         beginning = endPos;
                         ending = startPos;
                    }
                   
                    for (int i = beginning.X; i < ending.X+1; i++)
                    {
                        grid.Add(new GridPosition { Y = beginning.Y, X = i });
                        var count = grid.Count(gp => gp.Y == beginning.Y && gp.X == i);
                        Console.WriteLine(count);
                    }

                }

                if (columnRange)
                {
                    var beginning = startPos;
                    var ending = endPos;
                    if (startPos.Y > endPos.Y)
                    {
                        beginning = endPos;
                        ending = startPos;
                    }

                    for (int i = beginning.Y; i < ending.Y+1; i++)
                    {
                        grid.Add(new GridPosition { Y = i, X = beginning.X });
                        var count = grid.Count(gp => gp.X == beginning.X && gp.Y == i);
                        Console.WriteLine(count);
                    }


                }

            }
            Console.WriteLine(grid.Count());



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
            var day4Input = System.IO.File.ReadAllText("Day4Input.txt");
            var numbersRead = day4Input.Split("\r\n\r\n").First().Split(",").Select(s => int.Parse(s));
            var bingoGrids = PopulateBingoGridsFromInput(day4Input);

            foreach (var numberRead in numbersRead)
            {
                for (int gridNumber = 0; gridNumber < bingoGrids.Count; gridNumber++)
                {
                    BingoGrid bingoGrid = bingoGrids[gridNumber];

                    bingoGrid.CheckNumberAndMarkWinners(numberRead);

                }
            }
            var firstWinningGrid = bingoGrids.Where(bg => bg.FirstWinningSequence.Any()).OrderBy(wg => wg.CalledNumbers.Count).First();
            var lastWinningGrid = bingoGrids.Where(bg => bg.FirstWinningSequence.Any()).OrderBy(wg => wg.CalledNumbers.Count).Last();

            //part1
            DisplayFinalScore(firstWinningGrid);
            
            //part2
            DisplayFinalScore(lastWinningGrid);

        }

        private static void DisplayFinalScore(BingoGrid winningGrid)
        {
            var winningGridAsText = "";
            foreach (var row in winningGrid.Rows)
            {
                winningGridAsText += (string.Join(' ', row.Select(r => r.Value)) + "\r\n");

            }
            Console.WriteLine($"firstWinningGrid:\r\n{winningGridAsText}");
            Console.WriteLine($"firstWinningSequence: {string.Join(' ', winningGrid.FirstWinningSequence.Select(ge => ge.Value))}");
            var sumOfLosers = winningGrid.SumOfLosersAtPointOfWinning;
            var lastCalledNumberWhenWon = winningGrid.CalledNumbers.Last();
            Console.WriteLine($"sum of losers on grid: {sumOfLosers}");
            Console.WriteLine($"last winning number: {lastCalledNumberWhenWon}");
            Console.WriteLine($"Final Score: {sumOfLosers * lastCalledNumberWhenWon}");
        }

        private static List<BingoGrid> PopulateBingoGridsFromInput(string input)
        {

            string pattern = @"(\r\n[\d|\s\d].+){5}";
            Regex rx = new Regex(pattern);

            var matchedGrids = rx.Matches(input);
            var bingoGrids = new List<List<string[]>>();
            //populate/ format bingo grids
            foreach (var grid in matchedGrids)
            {
                var matchedGrid = (Match)grid;

                var gridAstext = matchedGrid.Value.Split("\\r\\n", StringSplitOptions.RemoveEmptyEntries).First();
                var gridOfLinesFormatted = gridAstext.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
                bingoGrids.Add(gridOfLinesFormatted.ToList());
            }

            var computedGrids = new List<BingoGrid>();
            for (int gridCount = 0; gridCount < bingoGrids.Count; gridCount++)
            {
                var computedGrid = new BingoGrid
                {
                    GridEntries = new List<GridEntry>()
                };
                var bingoGrid = bingoGrids[gridCount].Select(l => l.Select(e => int.Parse(e))).ToArray();
                for (int lineCount = 0; lineCount < bingoGrid.Count(); lineCount++)
                {
                    var line = bingoGrid[lineCount].ToArray();
                    for (int entryCount = 0; entryCount < bingoGrid.Count(); entryCount++)
                    {
                        computedGrid.GridEntries.Add(new GridEntry { Position = new GridPosition { X = entryCount, Y = lineCount }, Value = line[entryCount] });
                    }
                }
                computedGrid.PopulateRowsAndColumns();
                computedGrids.Add(computedGrid);
            }

            return computedGrids;
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
