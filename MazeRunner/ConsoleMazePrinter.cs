using System;

namespace MazeRunner
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
            for (int i = 0; i < MazeToPrint.M; i++)
            {
                for (int j = 0; j < MazeToPrint.N; j++)
                {
                    if (MazeToPrint.StartPoint == (i, j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("AA");
                    }
                    else if (MazeToPrint.EndPoint == (i, j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("BB");
                    }
                    else if (labyrinth[i, j] == -1)
                    {
                        Console.Write("██");
                    }
                    else if (labyrinth[i, j] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("██");
                    }
                    else if (labyrinth[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
