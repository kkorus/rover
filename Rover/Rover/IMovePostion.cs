namespace Rover
{
    public interface IMovePostion : IPosition
    {
        IMovePostion Forward();
        IMovePostion Backward();
        IMovePostion TurnLeft();
        IMovePostion TurnRight();
    }
}