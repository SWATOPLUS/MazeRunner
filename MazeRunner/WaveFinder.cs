using System.Collections.Generic;
using System.Linq;

namespace MazeRunner
{
    class WaveFinder : IWayFinder
    {
        private int _amountOfPointsUncovered;
        private Queue<(int, int)> Queue { get; } = new Queue<(int, int)>();
        public Maze Maze { get; }
        public int[,] MarkedCells { get; }
        public int Length { get; set; }

        public WaveFinder(Maze maze)
        {
            Maze = maze;
            _amountOfPointsUncovered = Maze.Rows * Maze.Columns - Maze.Walls.Length;

            MarkedCells = new int[Maze.Cells.GetLength(0), Maze.Cells.GetLength(1)];

            foreach (var x in Enumerable.Range(0, Maze.Rows))
            foreach (var y in Enumerable.Range(0, Maze.Columns))
            {
                MarkedCells[x, y] = Maze.Cells[x, y] == MazeCellType.Wall ? -1 : 0;
            }
        }

        public void FindWay()
        {
            Queue.Enqueue(Maze.StartPoint);
            while(_amountOfPointsUncovered>0 
                && MarkedCells[Maze.EndPoint.Item1, Maze.EndPoint.Item2] == 0)
            {
                MarkNeighbours(Queue.Dequeue());
            }
            Length = MarkedCells[Maze.EndPoint.Item1, Maze.EndPoint.Item2];

            Queue.Clear();
            var point = Maze.EndPoint;
            for (int k = Length-1; k > 0; k--)
            {
                QueueRightNeighbours(point, k);
                point = Queue.Dequeue();
                Maze.Cells[point.Item1, point.Item2] = MazeCellType.Path;
                Queue.Clear();
            }

        }

        private void MarkNeighbours((int, int) point)
        {
            MarkPoint((point.Item1 - 1, point.Item2), MarkedCells[point.Item1, point.Item2] + 1);
            MarkPoint((point.Item1, point.Item2 - 1), MarkedCells[point.Item1, point.Item2] + 1);
            MarkPoint((point.Item1, point.Item2 + 1), MarkedCells[point.Item1, point.Item2] + 1);
            MarkPoint((point.Item1 + 1, point.Item2), MarkedCells[point.Item1, point.Item2] + 1);
        }

        private void MarkPoint((int,int) point, int mark)
        {
            if(point!=Maze.StartPoint && 
                point.Item1 >= 0 && point.Item1 < Maze.Rows &&
                point.Item2 >= 0 && point.Item2 < Maze.Columns &&
                MarkedCells[point.Item1, point.Item2] == 0)
            {
                MarkedCells[point.Item1, point.Item2] = mark;
                _amountOfPointsUncovered--;
                Queue.Enqueue(point);
            }
        }

        private void QueueRightNeighbours((int, int) point, int mark)
        {
            if (CheckPoint((point.Item1, point.Item2 - 1), mark))
                Queue.Enqueue((point.Item1, point.Item2 - 1));
            if (CheckPoint((point.Item1, point.Item2 + 1), mark))
                Queue.Enqueue((point.Item1, point.Item2 + 1));
            if (CheckPoint((point.Item1 - 1, point.Item2), mark))
                Queue.Enqueue((point.Item1 - 1, point.Item2));
            if (CheckPoint((point.Item1 + 1, point.Item2), mark))
                Queue.Enqueue((point.Item1 + 1, point.Item2));
        }

        private bool CheckPoint((int, int) point, int mark)
        {
            if (point.Item1 >= 0 && point.Item1 < Maze.Rows &&
                point.Item2 >= 0 && point.Item2 < Maze.Columns &&
                MarkedCells[point.Item1, point.Item2] == mark)
            {
                return true;
            }
            return false;
        }
    }
}
