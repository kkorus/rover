using System;
using System.Collections.Generic;
using System.Linq;

namespace Rover
{
    public class Rover : IRover
    {
        private readonly IPlanet _planet;
        private IMovePostion _currentPosition;
        private readonly IDictionary<char, Func<IMovePostion>> _commandLookup;
        private readonly IEnumerable<char> _validCommands = new[] { 'F', 'B', 'L', 'R' };

        public Rover(IPlanet planet)
        {
            _planet = planet;
            _currentPosition = new Position(new Point(0, 0), Direction.North, planet);
            _commandLookup = new Dictionary<char, Func<IMovePostion>>
            {
                {'F', () => _currentPosition.Forward()},
                {'B', () => _currentPosition.Backward()},
                {'L', () => _currentPosition.TurnLeft()},
                {'R', () => _currentPosition.TurnRight()}
            };
        }

        public Coordinate Coordinate => _currentPosition.Coordinate;

        public MoveResult Move(string commands)
        {
            if (string.IsNullOrWhiteSpace(commands)) throw new ArgumentException($"Commands can't empty. {nameof(commands)}");
            if (commands.ToCharArray().Any(c => !_validCommands.Contains(c))) throw new InvalidMoveCommandException("Invalid command detected");

            foreach (var command in commands)
            {
                var nextPosition = _commandLookup[command]();
                if (IsObstacle(nextPosition.Coordinate))
                {
                    return MoveResult.CreateObstacleResult(_currentPosition.Coordinate, nextPosition.Coordinate.Point);
                }

                _currentPosition = nextPosition;
            }

            return MoveResult.CreateMoveResult(_currentPosition.Coordinate);
        }

        private bool IsObstacle(Coordinate coordinate) => _planet.Obstacles.Contains(coordinate.Point);
    }
}
