using System;
using System.Collections.Generic;

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
        private const int DirectionCount = 4;

        private readonly IPlanet _planet;
        private readonly IDictionary<Direction, Func<IMovePostion>> _forwardLookup;
        private readonly IDictionary<Direction, Func<IMovePostion>> _backwardLookup;

        public Position(Point point, Direction direction, IPlanet planet)
        {
            _planet = planet;
            Coordainte = new Coordainte(point, direction);

            _forwardLookup = new Dictionary<Direction, Func<IMovePostion>>
            {
                { Direction.North,  MoveTop },
                { Direction.South, MoveBottom },
                { Direction.East, MoveRight},
                { Direction.West, MoveLeft }
            };
            _backwardLookup = new Dictionary<Direction, Func<IMovePostion>>
            {
                { Direction.North,  MoveBottom },
                { Direction.South, MoveTop },
                { Direction.East, MoveLeft},
                { Direction.West, MoveRight }
            };
        }

        public Coordainte Coordainte { get; }

        public IMovePostion Forward() => _forwardLookup[Direction]();

        public IMovePostion Backward() => _backwardLookup[Direction]();

        public IMovePostion TurnLeft() => CreateNextPosition(X, Y, (Direction)Decrement((int)Direction, DirectionCount));

        public IMovePostion TurnRight() => CreateNextPosition(X, Y, (Direction)Increment((int)Direction, DirectionCount));

        private IMovePostion MoveTop() => CreateNextPosition(X, Increment(Y, _planet.Length), Direction);

        private IMovePostion MoveBottom() => CreateNextPosition(X, Decrement(Y, _planet.Length), Direction);

        private IMovePostion MoveRight() => CreateNextPosition(Increment(X, _planet.Width), Y, Direction);

        private IMovePostion MoveLeft() => CreateNextPosition(Decrement(X, _planet.Width), Y, Direction);

        private int X => Coordainte.Point.X;

        private int Y => Coordainte.Point.Y;

        private Direction Direction => Coordainte.Direction;

        private static int Increment(int toIncrement, int limitWrap) => (toIncrement + 1) % limitWrap;

        private static int Decrement(int toDecrement, int limitWrap) => (limitWrap + toDecrement - 1) % limitWrap;

        private IMovePostion CreateNextPosition(int x, int y, Direction direction) => new Position(new Point(x, y), direction, _planet);
    }
}