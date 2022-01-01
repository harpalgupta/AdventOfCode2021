using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Models
{
    public class BingoGrid
    {

        private int gridDimension = 5;
        public int CountOfNumbersRead { get; set; } = 0;

        public int SumOfLosersAtPointOfWinning;

        public List<List<GridEntry>> rows { get; private set; }
        public List<List<GridEntry>> columns { get; private set; }
        public List<GridEntry> GridEntries { get; set; }
        public List<GridEntry> FirstWinningSequence { get; private set; }

        public void PopulateRowsAndColumns()
        {
            rows = GetRowsorColumns(Direction.Row);
            columns = GetRowsorColumns(Direction.Column);

        }
        public void CheckNumberAndMarkWinners(int calledNumber)
        {
            if (FirstWinningSequence.Any())
            {
                return;
            }


            foreach (var row in rows)
            {
                foreach (var ge in row)
                {
                    if (ge.Value == calledNumber)
                    {
                        ge.Winner = true;
                    }
                }
                if (row.Count(ge => ge.Winner) == 5 &! FirstWinningSequence.Any())
                {
                    FirstWinningSequence= row;
                    SumOfLosersAtPointOfWinning = GridEntries.Where(ge => !ge.Winner).Sum(ge => ge.Value);

                }
                else
                {
                    this.CountOfNumbersRead++;
                }
            }

            foreach (var column in columns)
            {
                foreach (var ge in column)
                {
                    if (ge.Value == calledNumber)
                    {
                        ge.Winner = true;
                    }
                }
                if (column.Count(ge => ge.Winner) == 5 &! FirstWinningSequence.Any())
                {
                        FirstWinningSequence = column;
                }
            }
  
        }


        public void CheckWinningLine()
        {
            var rows = GetRowsorColumns(Direction.Row);
            foreach (var row in rows)
            {
                if(row.Count(ge=>ge.Winner) == 5)
                {
                    Console.WriteLine(row.Select(ge=>string.Join(' ',ge.Value)));
                }
            }
        }

        public int GetSumOfAllLosers()
        {
            return this.GridEntries.Where(ge => ge.Winner== false).Sum(ge => ge.Value);
        }

        public int GetSumOfGrid()
        {
            return this.GridEntries.Sum(ge => ge.Value);
        }

        public List<List<GridEntry>> GetRowsorColumns(Direction direction)
        {
            var rowsOrColumn = new List<List<GridEntry>>();
            if (direction == Direction.Row)
            {
                for (int i = 0; i < gridDimension; i++)
                {
                    var row = GridEntries.Where(ge => ge.Position.Y == i).ToList();
                    rowsOrColumn.Add(row);
                }
            }
            else if (direction == Direction.Column)
            {
                for (int i = 0; i < gridDimension; i++)
                {
                    var row = GridEntries.Where(ge => ge.Position.X == i).ToList();
                    rowsOrColumn.Add(row);
                }
            }

            return rowsOrColumn.ToList();
        }

        public List<IEnumerable<GridEntry>> GetColumns()
        {
            var rows = new List<IEnumerable<GridEntry>>();
            for (int i = 0; i < gridDimension; i++)
            {
                var row = GridEntries.Where(ge => ge.Position.Y == i);
                rows.Add(row);
            }

            return rows.ToList();
        }

        private List<BingoGrid> PopulateBingoGridsFromInput(string input)
        {

            string pattern = @"(\r\n[\d|\s\d].+){5}";
            Regex rx = new Regex(pattern);

            var matchedGrids = rx.Matches(input);
            var bingoGrids = new List<List<string[]>>();
            //populate/ format bingo grids
            foreach (var grid in matchedGrids)
            {
                //var pattern1 = @"(?:\s)";
                //var regex = new Regex(pattern1);
                //var gridOfLines = new List<string[]>();
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
                computedGrids.Add(computedGrid);
            }

            return computedGrids;
        }

    }


}