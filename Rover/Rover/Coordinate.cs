namespace Rover
{
    public class Coordinate
    {
        public Coordinate(Point point, Direction direction)
        {
            Point = point;
            Direction = direction;
        }

        public Point Point { get; }

        public Direction Direction { get; }
    }
}