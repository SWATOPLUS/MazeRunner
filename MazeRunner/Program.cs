using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze greatMaze = new Maze(36, 32);
            IMazePrinter consolePrinter = new ConsoleMazePrinter(greatMaze);
            consolePrinter.Print(greatMaze.Labyrinth);
            IWayFinder waveFinder = new WaveFinder(greatMaze);
            waveFinder.FindWay();
            System.Console.WriteLine("------------------------------------");
            consolePrinter.Print(greatMaze.Labyrinth);
            System.Console.WriteLine("Route Length = " + waveFinder.Length);
        }
    }
}
