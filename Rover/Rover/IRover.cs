namespace Rover
{
    public interface IRover
    {
        Coordainte Coordinate { get; }

        MoveResult Move(string commands);
    }
}