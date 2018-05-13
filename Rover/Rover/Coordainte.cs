namespace Rover
{
    public class Coordainte
    {
        public Coordainte(Point point, Direction direction)
        {
            Point = point;
            Direction = direction;
        }

        public Point Point { get; }

        public Direction Direction { get; }
    }
}