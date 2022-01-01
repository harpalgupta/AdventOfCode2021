using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Models
{
    public class BingoGrid
    {

        private readonly int gridDimension = 5;
        public List<int> CalledNumbers = new List<int>();

        public int SumOfLosersAtPointOfWinning;

        public List<List<GridEntry>> Rows { get; private set; }
        public List<List<GridEntry>> Columns { get; private set; }
        public List<GridEntry> GridEntries { get; set; }
        public List<GridEntry> FirstWinningSequence { get; private set; }

        public BingoGrid()
        {
            GridEntries = new List<GridEntry>();
            FirstWinningSequence = new List<GridEntry>();
        }
        public void PopulateRowsAndColumns()
        {
            Rows = GetRowsorColumns(Direction.Row);
            Columns = GetRowsorColumns(Direction.Column);

        }
        public void CheckNumberAndMarkWinners(int calledNumber)
        {
            if (FirstWinningSequence.Any())
            {
                return;
            }


            foreach (var row in Rows)
            {
                foreach (var ge in row)
                {
                    if (ge.Value == calledNumber)
                    {
                        ge.Winner = true;
                    }
                }
                if (row.Count(ge => ge.Winner) == 5 & !FirstWinningSequence.Any())
                {
                    FirstWinningSequence = row;
                    SumOfLosersAtPointOfWinning = GridEntries.Where(ge => !ge.Winner).Sum(ge => ge.Value);

                }
                else
                {
                    this.CalledNumbers.Add(calledNumber);
                }
            }

            foreach (var column in Columns)
            {
                foreach (var ge in column)
                {
                    if (ge.Value == calledNumber)
                    {
                        ge.Winner = true;
                    }
                }
                if (column.Count(ge => ge.Winner) == 5 & !FirstWinningSequence.Any())
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
                if (row.Count(ge => ge.Winner) == 5)
                {
                    Console.WriteLine(row.Select(ge => string.Join(' ', ge.Value)));
                }
            }
        }

        public int GetSumOfAllLosers()
        {
            return this.GridEntries.Where(ge => ge.Winner == false).Sum(ge => ge.Value);
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
    }


}