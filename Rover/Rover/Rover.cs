﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Rover
{
    public class Rover : IRover
    {
        private readonly IPlanet _planet;
        private IMovePostion _currentPosition;
        private readonly IEnumerable<char> _validCommands = new[] { 'F', 'B', 'L', 'R' };

        public Rover(IPlanet planet)
        {
            _planet = planet;
            _currentPosition = new Position(new Point(0, 0), Direction.North, planet);
        }

        public Coordainte Coordinate => _currentPosition.Coordainte;

        public MoveResult Move(string commands)
        {
            if (string.IsNullOrWhiteSpace(commands)) throw new ArgumentException($"Commands can't empty. {nameof(commands)}");
            if (commands.ToCharArray().Any(c => !_validCommands.Contains(c))) throw new InvalidMoveCommandException("Invalid command detected");

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        {
                            var nextPosition = _currentPosition.Forward();
                            if (IsObstacle(nextPosition.Coordainte))
                                return MoveResult.CreateObstacleResult(_currentPosition.Coordainte,
                                    nextPosition.Coordainte.Point);
                            _currentPosition = nextPosition;
                            break;
                        }
                    case 'B':
                        {
                            var nextPosition = _currentPosition.Backward();
                            if (IsObstacle(nextPosition.Coordainte))
                                return MoveResult.CreateObstacleResult(_currentPosition.Coordainte, nextPosition.Coordainte.Point);
                            _currentPosition = nextPosition;
                            break;
                        }
                    case 'L':
                        {
                            var nextPosition = _currentPosition.TurnLeft();
                            if (IsObstacle(nextPosition.Coordainte))
                                return MoveResult.CreateObstacleResult(_currentPosition.Coordainte, nextPosition.Coordainte.Point);
                            _currentPosition = nextPosition;
                            break;
                        }
                    case 'R':
                        {
                            var nextPosition = _currentPosition.TurnRight();
                            if (IsObstacle(nextPosition.Coordainte))
                                return MoveResult.CreateObstacleResult(_currentPosition.Coordainte, nextPosition.Coordainte.Point);
                            _currentPosition = nextPosition;
                            break;
                        }
                }
            }

            return MoveResult.CreateMoveResult(_currentPosition.Coordainte);
        }

        private bool IsObstacle(Coordainte coordainte) => _planet.Obstacles.Contains(coordainte.Point);
    }
}
