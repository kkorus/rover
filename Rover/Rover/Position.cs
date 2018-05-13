namespace Rover
{
    public interface IPosition
    {
        Coordainte Coordainte { get; }
    }

    public interface IMovePostion : IPosition
    {
        IMovePostion Forward();
        IMovePostion Backward();
        IMovePostion TurnLeft();
        IMovePostion TurnRight();
    }

    public class Position : IMovePostion
    {
        private readonly Coordainte _coordainte;

        public Position(Point point, Direction direction)
        {
            _coordainte = new Coordainte(point, direction);
        }

        public IMovePostion Forward()
        {
            return new Position(new Point(Point.X, Point.Y + 1), _coordainte.Direction);
        }


        public IMovePostion Backward()
        {
            return new Position(new Point(Point.X, Point.Y - 1), _coordainte.Direction);
        }

        public IMovePostion TurnLeft()
        {
            var nextDirection = Direction == Direction.North
                ? Direction.West
                : Direction - 1;

            return new Position(Point, nextDirection);
        }

        public IMovePostion TurnRight()
        {
            var nextDirection = Direction == Direction.West
                ? Direction.North
                : Direction + 1;

            return new Position(Point, nextDirection);
        }

        public Coordainte Coordainte => _coordainte;

        private Point Point => _coordainte.Point;

        private Direction Direction => _coordainte.Direction;
    }
}