namespace MazeRunner
{
    interface IWayFinder
    {
        int Length { get; set; }

        void FindWay();
    }
}
