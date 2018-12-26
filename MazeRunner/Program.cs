using System;

namespace MazeRunner
{
    internal static class Program
    {
        private static void Main()
        {
            var greatMaze = new Maze(36, 32);
            IMazePrinter consolePrinter = new ConsoleMazePrinter(greatMaze);
            consolePrinter.Print(greatMaze.Labyrinth);

            IWayFinder waveFinder;

            try
            {
                waveFinder = new WaveFinder(greatMaze);
                waveFinder.FindWay();
            }
            catch (Exception)
            {
                Console.WriteLine("Path not found");
                return;
            }

            Console.WriteLine("------------------------------------");
            consolePrinter.Print(greatMaze.Labyrinth);
            Console.WriteLine("Route Length = " + waveFinder.Length);
        }
    }
}

