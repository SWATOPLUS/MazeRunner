using System;

namespace MazeRunner
{
    public class ConsoleMazePrinter : IMazePrinter
    {
        public void Print(MazeCellType[,] cells)
        {
            for (var i = 0; i < cells.GetLength(0); i++)
            {
                for (var j = 0; j < cells.GetLength(1); j++)
                {
                    switch (cells[i, j])
                    {
                        case MazeCellType.Start:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("AA");
                            break;

                        case MazeCellType.Finish:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("BB");
                            break;

                        case MazeCellType.Wall:
                            Console.Write("██");
                            break;

                        case MazeCellType.Path:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("██");
                            break;

                        case MazeCellType.Empty:
                            Console.Write("  ");
                            break;

                        default:
                            throw new NotImplementedException();
                    }

                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
