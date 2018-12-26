using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeRunner
{
    public class Maze
    {
        private static Random Random { get; } = new Random();

        public int Rows { get; }
        public int Columns { get; }
        public (int, int)[] Walls { get; set; }
        public (int, int) StartPoint { get; set; }
        public (int, int) EndPoint { get; set; }
        public MazeCellType[,] Cells { get; }

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new MazeCellType[rows,columns];
            InitializeBlocks();
            InitializeStartAndEndPoints();
        }

        private void InitializeBlocks()
        {
            var amountOfBlocks = (int)Math.Ceiling((double)Columns * Columns * Rows / 100);
            Walls = new (int, int)[amountOfBlocks];
            for (int l = 0; l < amountOfBlocks; l++)
            {
                var point = RandomEmptyPoint();
                Cells[point.Item1, point.Item2] = MazeCellType.Wall;
                Walls[l] = point;
            }
        }

        private void InitializeStartAndEndPoints()
        {
            EndPoint = RandomEmptyPoint();
            StartPoint = RandomEmptyPoint();
            Cells[EndPoint.Item1, EndPoint.Item2] = MazeCellType.Finish;
            Cells[StartPoint.Item1, StartPoint.Item2] = MazeCellType.Start;
        }

        private (int, int) RandomEmptyPoint()
        {
            var emptyCells = new List<(int, int)>(Cells.Length);

            foreach (var x in Enumerable.Range(0, Rows))
            foreach (var y in Enumerable.Range(0, Columns))
            {
                if (Cells[x, y] == MazeCellType.Empty)
                {
                    emptyCells.Add((x, y));
                }
            }

            return emptyCells[Random.Next(emptyCells.Count)];
        }
    }
}
