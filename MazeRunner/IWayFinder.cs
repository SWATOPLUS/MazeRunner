namespace MazeRunner
{
    interface IWayFinder
    {
        int[,] Labyrinth { get; set; }
        int Length { get; set; }

        void FindWay();
    }
}
