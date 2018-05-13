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
        private readonly Coordainte _coordainte;
        private readonly IPlanet _planet;
        private readonly IDictionary<Direction, Func<IMovePostion>> _forwardLookup;
        private readonly IDictionary<Direction, Func<IMovePostion>> _backwardLookup;

        public Position(Point point, Direction direction, IPlanet planet)
        {
            _planet = planet;
            _coordainte = new Coordainte(point, direction);

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

        public IMovePostion Forward()
        {
            return _forwardLookup[Direction]();
        }

        public IMovePostion Backward()
        {
            return _backwardLookup[Direction]();
        }

        public IMovePostion TurnLeft()
        {
            var nextDirection = Direction == Direction.North
                ? Direction.West
                : Direction - 1;

            return new Position(Point, nextDirection, _planet);
        }

        public IMovePostion TurnRight()
        {
            var nextDirection = Direction == Direction.West
                ? Direction.North
                : Direction + 1;

            return new Position(Point, nextDirection, _planet);
        }

        private IMovePostion MoveTop() => CreateNextPosition(X, Increment(Y, _planet.Length), Direction);

        private IMovePostion MoveBottom() => CreateNextPosition(X, Decrement(Y, _planet.Length), Direction);

        private IMovePostion MoveRight() => CreateNextPosition(Increment(X, _planet.Width), Y, Direction);

        private IMovePostion MoveLeft() => CreateNextPosition(Decrement(X, _planet.Width), Y, Direction);

        public Coordainte Coordainte => _coordainte;

        private Point Point => _coordainte.Point;

        private int X => _coordainte.Point.X;

        private int Y => _coordainte.Point.Y;

        private Direction Direction => _coordainte.Direction;

        private static int Increment(int toIncrement, int limitWrap) => (toIncrement + 1) % limitWrap;

        private static int Decrement(int toDecrement, int limitWrap) => (limitWrap + toDecrement - 1) % limitWrap;

        private IMovePostion CreateNextPosition(int x, int y, Direction direction) => new Position(new Point(x, y), direction, _planet);
    }
}