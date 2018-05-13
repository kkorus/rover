namespace Rover
{
    public interface IRover
    {
        Coordinate Coordinate { get; }

        MoveResult Move(string commands);
    }
}