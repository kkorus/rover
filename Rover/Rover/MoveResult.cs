namespace Rover
{
    public class MoveResult
    {
        public bool ObstacleDetected { get; }

        public Point? ObstaclePoint { get; }

        public Coordainte LastCoordainte { get; }

        public MoveResult(Coordainte lastCoordainte, bool obstacleDetected, Point? obstaclePoint = null)
        {
            ObstacleDetected = obstacleDetected;
            ObstaclePoint = obstaclePoint;
            LastCoordainte = lastCoordainte;
        }

        public static MoveResult CreateObstacleResult(Coordainte lastCoordainte, Point position) => new MoveResult(lastCoordainte, true, position);

        public static MoveResult CreateMoveResult(Coordainte lastCoordainte) => new MoveResult(lastCoordainte, false);
    }
}