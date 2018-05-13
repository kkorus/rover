namespace Rover
{
    public interface IPlanet
    {
        int Length { get; }

        int Width { get; }
    }

    public class Planet : IPlanet
    {
        public Planet(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public int Length { get; }

        public int Width { get; }
    }
}
