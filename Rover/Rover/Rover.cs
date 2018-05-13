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

        public Coordainte Coordinate => _currentPosition.Coordainte;

        public MoveResult Move(string commands)
        {
            if (string.IsNullOrWhiteSpace(commands)) throw new ArgumentException($"Commands can't empty. {nameof(commands)}");
            if (commands.ToCharArray().Any(c => !_validCommands.Contains(c))) throw new InvalidMoveCommandException("Invalid command detected");

            foreach (var command in commands)
            {
                var nextPosition = _commandLookup[command]();
                if (IsObstacle(nextPosition.Coordainte))
                {
                    return MoveResult.CreateObstacleResult(_currentPosition.Coordainte, nextPosition.Coordainte.Point);
                }

                _currentPosition = nextPosition;
            }

            return MoveResult.CreateMoveResult(_currentPosition.Coordainte);
        }

        private bool IsObstacle(Coordainte coordainte) => _planet.Obstacles.Contains(coordainte.Point);
    }
}
