namespace Rover
{
    public class MoveResult
    {
        public bool ObstacleDetected { get; }

        public Point? ObstaclePoint { get; }

        public Coordinate LastCoordinate { get; }

        public MoveResult(Coordinate lastCoordinate, bool obstacleDetected, Point? obstaclePoint = null)
        {
            ObstacleDetected = obstacleDetected;
            ObstaclePoint = obstaclePoint;
            LastCoordinate = lastCoordinate;
        }

        public static MoveResult CreateObstacleResult(Coordinate lastCoordinate, Point position) => new MoveResult(lastCoordinate, true, position);

        public static MoveResult CreateMoveResult(Coordinate lastCoordinate) => new MoveResult(lastCoordinate, false);
    }
}