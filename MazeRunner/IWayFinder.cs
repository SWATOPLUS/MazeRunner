using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner.Console
{
    interface IWayFinder
    {
        int[,] Labyrinth { get; set; }
        int Length { get; set; }

        void FindWay();
    }
}
