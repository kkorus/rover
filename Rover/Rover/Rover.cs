namespace Rover
{
    public interface IRover
    {
        Coordainte Coordinate { get; }

        MoveResult Move(string commands);
    }

    public class Rover : IRover
    {
        private IMovePostion _currentPosition;

        public Rover()
        {
            _currentPosition = new Position(new Point(0, 0), Direction.North);
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
                }
            }

            return MoveResult.CreateMoveResult(_currentPosition.Coordainte);
        }
    }
}
