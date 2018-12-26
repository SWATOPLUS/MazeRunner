using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner.Console
{
    interface IMazePrinter
    {
        void Print(int[,] labyrinth);
    }
}
