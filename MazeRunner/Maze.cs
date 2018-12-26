using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner.Console
{
    class Maze
    {
        public int M { get; set; }
        public int N { get; set; }
        public (int, int)[] Blocks { get; set; }
        public (int, int) StartPoint { get; set; }
        public (int, int) EndPoint { get; set; }
        public int[,] Labyrinth { get; set; }

        public Maze(int m, int n)
        {
            M = m;
            N = n;
            Labyrinth = new int[m,n];
            InitializeBlocks();
            InitializeStartAndEndPoints();
        }

        private void InitializeBlocks()
        {
            var amountOfBlocks = (int)Math.Ceiling((double)N * N * M / 100);
            Blocks = new (int, int)[amountOfBlocks];
            for (int l = 0; l < amountOfBlocks; l++)
            {
                var point = RandomPoint();
                Labyrinth[point.Item1, point.Item2] = -1;
                Blocks[l] = point;
            }
        }

        private void InitializeStartAndEndPoints()
        {
            EndPoint = RandomPoint();
            StartPoint = RandomPoint();
        }

        private (int,int) RandomPoint()
        {
            Random rand = new Random();
            var i = rand.Next(M);
            var j = rand.Next(N);
            while (Labyrinth[i, j] == -1 || (i,j) == StartPoint || (i,j) == EndPoint)
            {
                i = rand.Next(M);
                j = rand.Next(N);
            }
            return (i, j);
        }

    }
}
