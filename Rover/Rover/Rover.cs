﻿namespace Rover
{
    public interface IRover
    {
        Coordainte Coordinate { get; }

        MoveResult Move(string commands);
    }

    public class Rover : IRover
    {
        private readonly IPlanet _planet;
        private IMovePostion _currentPosition;

        public Rover(IPlanet planet)
        {
            _planet = planet;
            _currentPosition = new Position(new Point(0, 0), Direction.North, planet);
        }

        public Coordainte Coordinate => _currentPosition.Coordainte;

        public MoveResult Move(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        _currentPosition = _currentPosition.Forward();
                        break;
                    case 'B':
                        _currentPosition = _currentPosition.Backward();
                        break;
                    case 'L':
                        _currentPosition = _currentPosition.TurnLeft();
                        break;
                    case 'R':
                        _currentPosition = _currentPosition.TurnRight();
                        break;
                }
            }

            return MoveResult.CreateMoveResult(_currentPosition.Coordainte);
        }
    }
}
