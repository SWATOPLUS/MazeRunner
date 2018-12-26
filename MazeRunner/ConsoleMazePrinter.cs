using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner.Console
{
    class ConsoleMazePrinter : IMazePrinter
    {
        public Maze MazeToPrint { get; set; }

        public ConsoleMazePrinter(Maze mazeToPrint)
        {
            MazeToPrint = mazeToPrint;
        }

        public void Print(int[,] labyrinth)
        {
            for(int i = 0; i < MazeToPrint.M; i++)
            {
                for(int j = 0; j < MazeToPrint.N; j++)
                {
                    if (MazeToPrint.StartPoint == (i, j))
                        System.Console.Write("A");
                    else if (MazeToPrint.EndPoint == (i, j))
                        System.Console.Write("B");
                    else if (labyrinth[i, j] == -1)
                        System.Console.Write("-");
                    else if (labyrinth[i, j] > 0)
                        System.Console.Write("X");
                    else
                        System.Console.Write(labyrinth[i, j]);
                }
                System.Console.Write('\n');
            }
        }
    }
}
