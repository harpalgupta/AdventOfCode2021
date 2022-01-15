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
            // Day5();
            //Day6();           
            Day7();

            Console.ReadKey();
        }

        private static void Day7()
        {
            int? fuels = null;
            //var horizontalPositions = "1101,1,29,67,1102,0,1,65,1008,65,35,66,1005,66,28,1,67,65,20,4,0,1001,65,1,65,1106,0,8,99,35,67,101,99,105,32,110,39,101,115,116,32,112,97,115,32,117,110,101,32,105,110,116,99,111,100,101,32,112,114,111,103,114,97,109,10,51,812,37,278,203,12,1699,10,24,482,200,197,433,141,1854,148,529,748,46,1366,41,329,300,29,159,767,661,238,586,940,139,1606,273,1093,1687,694,232,1069,264,162,752,250,138,471,828,72,285,136,817,258,586,308,191,478,43,750,570,38,207,1221,434,124,1410,125,743,7,827,963,873,263,478,938,686,250,1022,7,917,717,1354,618,639,24,113,417,550,279,919,736,75,117,1173,32,172,88,1435,15,442,232,272,102,253,113,173,86,57,536,1282,111,18,197,117,738,427,910,740,861,90,706,520,8,1,129,80,79,36,788,1545,119,971,1435,945,808,821,1080,227,1257,973,39,303,818,669,7,197,819,1683,50,2,1248,1459,669,210,653,978,76,509,173,304,183,228,45,1032,672,792,12,540,839,135,153,55,29,1190,42,395,626,487,54,831,956,1,1012,1461,929,561,34,733,629,49,146,469,220,1368,89,265,128,521,402,557,1121,853,240,655,100,341,137,525,371,288,1389,430,1148,398,130,174,176,982,74,923,1438,469,572,33,261,126,456,300,174,27,60,1052,428,196,403,394,392,40,474,27,351,194,619,657,722,181,300,448,1037,525,1388,854,1459,967,211,46,1708,1175,1225,613,1315,479,973,573,324,887,2,116,752,447,3,1074,1135,72,595,601,632,511,1349,267,164,6,1300,172,412,3,298,1120,93,161,176,141,150,67,37,144,421,45,1451,781,1120,205,487,344,372,150,136,614,265,536,1740,265,1367,0,322,204,76,97,1112,717,444,418,279,943,597,309,322,205,1167,292,18,383,367,621,770,13,243,1641,500,313,785,106,184,310,615,248,664,98,221,740,450,460,7,23,1226,183,75,449,806,721,1057,266,254,1083,0,125,27,151,16,664,73,94,44,1347,73,325,958,475,862,1096,1523,114,307,1418,46,113,188,462,194,535,282,1144,26,1106,1465,39,133,445,177,481,233,696,181,72,1466,747,266,44,311,1061,505,140,956,360,716,98,844,1059,305,162,1679,817,873,969,793,1079,320,318,70,417,1170,628,1628,1515,894,482,1757,423,1024,267,1280,10,474,806,684,378,425,816,243,388,27,116,569,777,946,593,646,91,639,508,63,405,1310,639,380,323,75,860,67,42,58,198,35,58,180,75,530,25,194,1743,476,1092,795,243,121,1326,409,1300,218,1393,371,64,412,209,255,648,480,71,125,1398,45,1035,1245,1426,1765,596,187,353,0,261,774,958,1303,397,1024,1076,1225,307,69,789,307,450,143,203,259,21,2,297,963,1236,1292,595,784,100,1194,1246,1820,534,58,244,12,194,1316,211,368,192,741,1232,23,87,551,291,12,512,6,42,1513,619,62,1339,375,743,137,1486,254,53,274,299,1443,844,899,753,414,241,161,52,163,66,86,503,823,528,150,376,403,1346,125,363,412,774,374,1090,1001,177,1379,74,193,49,92,294,679,108,228,199,1203,324,64,321,89,601,32,46,1274,519,1089,1107,63,379,1062,1034,129,736,716,156,526,445,1,299,388,444,1080,1016,101,735,315,517,13,390,537,155,140,1119,975,259,254,402,277,1160,372,55,392,1022,1119,4,735,266,260,1550,389,824,1426,23,65,480,151,176,1761,0,16,139,152,383,358,1155,95,1138,310,232,71,1073,22,1,335,1168,792,136,902,33,204,59,146,1063,1012,103,1083,160,885,445,499,473,278,451,191,1940,249,37,722,325,495,615,70,85,50,107,560,597,75,206,767,990,113,530,94,1343,250,116,67,417,390,500,633,736,132,473,646,1502,249,119,228,3,64,212,19,1005,324,14,418,619,847,20,878,533,204,49,820,216,34,60,62,119,680,88,359,8,473,882,138,387,297,419,664,693,420,101,53,829,3,101,272,726,639,368,363,0,33,70,0,626,525,364,784,271,73,536,318,598,794,34,314,1248,1596,764,34,202,1383,635,158,1095,76,0,119,176,1158,301,409,796,242,1765,808,59,0,278,4,8,359,1111,818,931,220,109,292,353,532,750,333,223,725,1476,199,1,201,55,72,117,37,210,400,108,619,863,187,372,15,574,380,635,332,1,1210,64,897,501,12,822,508,250,263,1044,72,15,210,901,219,471,292,179,572,733,422,1354,1197,202,538,662,261,973,0,465,522,412,9,166,325,237,757,115,1046,273,549,174,30,96,215,113,7,1032,671,262,202,332,1078,629,555,26,8,29,349,206,123,1093,673,1356,513,1454,518,1240,337,96,115,1160,17,331,1450,114,107,782,995,168".Split(',').Select(s=>int.Parse(s));
            var horizontalPositions = "16,1,2,0,4,2,7,1,2,14".Split(',').Select(s=>int.Parse(s));
            var step = 0;
            foreach (var hp in horizontalPositions)
            {
            var tempFuel =  horizontalPositions.Sum(p => Math.Abs(p - hp))+step;
                step++;
                if(tempFuel<fuels|| fuels == null)
                {
                    fuels = tempFuel;
                }

            }



            Console.WriteLine(fuels);

        }
        private static void Day6()
        {
            var day6Input = System.IO.File.ReadAllText("Day6Input.txt");
            var lanternFishes = day6Input.Split(',').Select(i => int.Parse(i)).ToList();

            var dictonaryOfLanternFishValuesCounts = new Dictionary<int, long>();
            
            // set initial values for dictionary
            for (int lanternFishValue = 0; lanternFishValue < 9; lanternFishValue++)
            {
                dictonaryOfLanternFishValuesCounts.Add(lanternFishValue, 0);
                var count = lanternFishes.Count(lf => lf == lanternFishValue);
                dictonaryOfLanternFishValuesCounts[lanternFishValue] += count;
            }

            var days = 256;

            for (int i = 1; i < days + 1; i++)
            {
                // Console.WriteLine($"day{i}");
                var tmpdictonaryOfLanternFishValuesCounts = new Dictionary<int, long>();
                for (int lanternFishValue = 0; lanternFishValue < 9; lanternFishValue++)
                {
                    tmpdictonaryOfLanternFishValuesCounts.Add(lanternFishValue, 0);
                }

                long numberOfZerosFromPreviousDay = dictonaryOfLanternFishValuesCounts[0];

                for (int lanternFishValue = 8; lanternFishValue != -1; lanternFishValue--)
                {
                    if (lanternFishValue > 0)
                    {
                        tmpdictonaryOfLanternFishValuesCounts[lanternFishValue - 1] =
                            dictonaryOfLanternFishValuesCounts[lanternFishValue];
                    }
                    else
                    {
                        if (numberOfZerosFromPreviousDay > 0)
                        {
                            tmpdictonaryOfLanternFishValuesCounts[6] += numberOfZerosFromPreviousDay;
                            tmpdictonaryOfLanternFishValuesCounts[8] += numberOfZerosFromPreviousDay;
                        }
                    }

                    Console.WriteLine(
                        $"new count of {lanternFishValue} {tmpdictonaryOfLanternFishValuesCounts[lanternFishValue]}");
                }

                dictonaryOfLanternFishValuesCounts = new Dictionary<int, long>(tmpdictonaryOfLanternFishValuesCounts);
            }

            Console.WriteLine(dictonaryOfLanternFishValuesCounts.Sum(lf => lf.Value));
        }

        private static void Day5()
        {
            var day5Input = System.IO.File.ReadAllLines("Day5Input.txt");
            var grid = new Dictionary<string, int>();
            var dictionaryOfTotals = new Dictionary<string, int>();
            foreach (var line in day5Input)
            {
                var positions = line.Split(new[] {" -> "}, StringSplitOptions.None);
                var start = positions[0].Split(',');
                var end = positions[1].Split(',');
                var startPos = new GridPosition {X = int.Parse(start[0]), Y = int.Parse(start[1])};
                var endPos = new GridPosition {X = int.Parse(end[0]), Y = int.Parse(end[1])};
                var columnRange = false;
                var rowRange = false;
                var diagonalRange = false;

                if (startPos.X == endPos.X && startPos.Y != endPos.Y)
                {
                    columnRange = true;
                }
                else if (startPos.Y == endPos.Y && startPos.X != endPos.X)
                {
                    rowRange = true;
                }
                else if (startPos.Y != endPos.Y && startPos.X != endPos.X)
                {
                    diagonalRange = true;
                }

                if (rowRange)
                {
                    var beginning = startPos;
                    var ending = endPos;
                    if (startPos.X > endPos.X)
                    {
                        beginning = endPos;
                        ending = startPos;
                    }

                    for (int i = beginning.X; i < ending.X + 1; i++)
                    {
                        if (grid.ContainsKey($"{i},{beginning.Y}"))
                        {
                            grid[$"{i},{beginning.Y}"]++;
                        }
                        else
                        {
                            grid.Add($"{i},{beginning.Y}", 1);
                        }
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

                    for (int i = beginning.Y; i < ending.Y + 1; i++)
                    {
                        if (grid.ContainsKey($"{beginning.X},{i}"))
                        {
                            grid[$"{beginning.X},{i}"]++;
                        }
                        else
                        {
                            grid.Add($"{beginning.X},{i}", 1);
                        }
                    }
                }

                if (diagonalRange)
                {
                    var beginning = startPos;
                    var ending = endPos;

                    var xDirection = 0;
                    var yDirection = 0;

                    if (ending.X > beginning.X)
                    {
                        xDirection = 1;
                    }

                    if (ending.X < beginning.X)
                    {
                        xDirection = -1;
                    }

                    if (ending.Y > beginning.Y)
                    {
                        yDirection = 1;
                    }

                    if (ending.Y < beginning.Y)
                    {
                        yDirection = -1;
                    }

                    var difference = Math.Abs(beginning.X - ending.X);

                    var currenPos = startPos;

                    if (grid.ContainsKey($"{currenPos.X},{currenPos.Y}"))
                    {
                        grid[$"{currenPos.X},{currenPos.Y}"]++;
                    }
                    else
                    {
                        grid.Add($"{currenPos.X},{currenPos.Y}", 1);
                    }

                    for (int i = 0; i < difference; i++)
                    {
                        currenPos.X += xDirection;
                        currenPos.Y += yDirection;

                        if (grid.ContainsKey($"{currenPos.X},{currenPos.Y}"))
                        {
                            grid[$"{currenPos.X},{currenPos.Y}"]++;
                        }
                        else
                        {
                            grid.Add($"{currenPos.X},{currenPos.Y}", 1);
                        }
                    }
                }
            }

            var countOfOverlappingPointsGreaterThenTwo = grid.Count(gp => gp.Value >= 2);

            Console.WriteLine(countOfOverlappingPointsGreaterThenTwo);
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

            var firstWinningGrid = bingoGrids.Where(bg => bg.FirstWinningSequence.Any())
                .OrderBy(wg => wg.CalledNumbers.Count).First();
            var lastWinningGrid = bingoGrids.Where(bg => bg.FirstWinningSequence.Any())
                .OrderBy(wg => wg.CalledNumbers.Count).Last();

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
            Console.WriteLine(
                $"firstWinningSequence: {string.Join(' ', winningGrid.FirstWinningSequence.Select(ge => ge.Value))}");
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
                var matchedGrid = (Match) grid;

                var gridAstext = matchedGrid.Value.Split("\\r\\n", StringSplitOptions.RemoveEmptyEntries).First();
                var gridOfLinesFormatted = gridAstext.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => n.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
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
                        computedGrid.GridEntries.Add(new GridEntry
                            {Position = new GridPosition {X = entryCount, Y = lineCount}, Value = line[entryCount]});
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