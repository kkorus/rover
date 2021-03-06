﻿using System.Collections.Generic;

namespace Rover
{
    public class Planet : IPlanet
    {
        public Planet(int length, int width) : this(width, length, new List<Point>())
        {
        }

        public Planet(int length, int width, IList<Point> obstacles)
        {
            Length = length;
            Width = width;
            Obstacles = obstacles;
        }

        public IList<Point> Obstacles { get; }

        public int Length { get; }

        public int Width { get; }
    }
}
