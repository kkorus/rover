using System.Collections.Generic;

namespace Rover
{
    public interface IPlanet
    {
        int Length { get; }

        int Width { get; }

        IList<Point> Obstacles { get; }
    }
}