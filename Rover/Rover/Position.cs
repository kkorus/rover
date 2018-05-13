namespace Rover
{
    public interface IMovePostion
    {
        IMovePostion Forward();
        IMovePostion Backward();
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
            return null;
        }

        public Coordainte Coordainte => _coordainte;

        private Point Point => _coordainte.Point;
    }
}