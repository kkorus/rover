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
        private readonly IDictionary<Direction, Func<IMovePostion>> _forwardLookup;
        private readonly IDictionary<Direction, Func<IMovePostion>> _backwardLookup;

        public Position(Point point, Direction direction)
        {
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

            return new Position(Point, nextDirection);
        }

        public IMovePostion TurnRight()
        {
            var nextDirection = Direction == Direction.West
                ? Direction.North
                : Direction + 1;

            return new Position(Point, nextDirection);
        }

        private IMovePostion MoveTop() => CreateNextPosition(Point.X, Point.Y + 1, Direction);

        private IMovePostion MoveBottom() => CreateNextPosition(Point.X, Point.Y - 1, Direction);

        private IMovePostion MoveRight() => CreateNextPosition(Point.X + 1, Point.Y, Direction);

        private IMovePostion MoveLeft() => CreateNextPosition(Point.X - 1, Point.Y, Direction);

        public Coordainte Coordainte => _coordainte;

        private Point Point => _coordainte.Point;

        private Direction Direction => _coordainte.Direction;

        private IMovePostion CreateNextPosition(int x, int y, Direction direction) => new Position(new Point(x, y), direction);
    }
}