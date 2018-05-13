namespace Rover
{
    public interface IRover
    {
        Coordainte Coordinate { get; }
    }

    public class Rover : IRover
    {
        private Coordainte _coordainte;

        public Rover()
        {
            _coordainte = new Coordainte(new Point(0, 0), Direction.North);
        }

        public Coordainte Coordinate => _coordainte;
    }
}
