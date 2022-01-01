using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Models
{
    public class BingoGrid
    {
        private int gridDimension = 5;
        public List<GridEntry> GridEntries { get; set; }

        public IEnumerable<GridEntry> CheckNumberAndMarkWinners(int calledNumber)
        {
            var rows = GetRowsorColumns(Direction.Row);
            var columns = GetRowsorColumns(Direction.Column);

            var firstWinningSequence = new List<GridEntry>();

            foreach (var row in rows)
            {
                foreach (var ge in row)
                {
                    if (ge.Value == calledNumber)
                    {
                        ge.Winner = true;
                    }
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
            }

            return firstWinningSequence.Any() ? firstWinningSequence : null;
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