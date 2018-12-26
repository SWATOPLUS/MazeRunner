using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner.Console
{
    class WaveFinder : IWayFinder
    {
        private int amountOfPointsUncovered;
        private Queue<(int, int)> queue;
        public Maze MazeToFindWay { get; set; }
        public int[,] Labyrinth { get; set; }
        public int Length { get; set; }

        public WaveFinder(Maze mazeToFindWay)
        {
            MazeToFindWay = mazeToFindWay;
            Labyrinth = (int[,])MazeToFindWay.Labyrinth.Clone();
            amountOfPointsUncovered = MazeToFindWay.M * MazeToFindWay.N - MazeToFindWay.Blocks.Length;
            queue = new Queue<(int, int)>();
        }

        public void FindWay()
        {
            queue.Enqueue(MazeToFindWay.StartPoint);
            while(amountOfPointsUncovered>0 
                && Labyrinth[MazeToFindWay.EndPoint.Item1, MazeToFindWay.EndPoint.Item2] == 0)
            {
                MarkNeighbours(queue.Dequeue());
            }
            Length = Labyrinth[MazeToFindWay.EndPoint.Item1, MazeToFindWay.EndPoint.Item2];

            queue.Clear();
            var point = MazeToFindWay.EndPoint;
            for (int k = Length-1; k > 0; k--)
            {
                QueueRightNeighbours(point, k);
                point = queue.Dequeue();
                MazeToFindWay.Labyrinth[point.Item1, point.Item2] = k;
                queue.Clear();
            }

        }

        private void MarkNeighbours((int, int) point)
        {
            MarkPoint((point.Item1 - 1, point.Item2), Labyrinth[point.Item1, point.Item2] + 1);
            MarkPoint((point.Item1, point.Item2 - 1), Labyrinth[point.Item1, point.Item2] + 1);
            MarkPoint((point.Item1, point.Item2 + 1), Labyrinth[point.Item1, point.Item2] + 1);
            MarkPoint((point.Item1 + 1, point.Item2), Labyrinth[point.Item1, point.Item2] + 1);
        }

        private void MarkPoint((int,int) point, int mark)
        {
            if(point!=MazeToFindWay.StartPoint && 
                point.Item1 >= 0 && point.Item1 < MazeToFindWay.M &&
                point.Item2 >= 0 && point.Item2 < MazeToFindWay.N &&
                Labyrinth[point.Item1, point.Item2] == 0)
            {
                Labyrinth[point.Item1, point.Item2] = mark;
                amountOfPointsUncovered--;
                queue.Enqueue(point);
            }
        }

        private void QueueRightNeighbours((int, int) point, int mark)
        {
            if (CheckPoint((point.Item1, point.Item2 - 1), mark))
                queue.Enqueue((point.Item1, point.Item2 - 1));
            if (CheckPoint((point.Item1, point.Item2 + 1), mark))
                queue.Enqueue((point.Item1, point.Item2 + 1));
            if (CheckPoint((point.Item1 - 1, point.Item2), mark))
                queue.Enqueue((point.Item1 - 1, point.Item2));
            if (CheckPoint((point.Item1 + 1, point.Item2), mark))
                queue.Enqueue((point.Item1 + 1, point.Item2));
        }

        private bool CheckPoint((int, int) point, int mark)
        {
            if (point.Item1 >= 0 && point.Item1 < MazeToFindWay.M &&
                point.Item2 >= 0 && point.Item2 < MazeToFindWay.N &&
                Labyrinth[point.Item1, point.Item2] == mark)
            {
                return true;
            }
            return false;
        }
    }
}
