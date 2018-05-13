namespace Rover
{
    public class MoveResult
    {
        public Coordainte LastCoordainte { get; }

        private MoveResult(Coordainte lastCoordainte)
        {
            LastCoordainte = lastCoordainte;
        }

        public static MoveResult CreateMoveResult(Coordainte lastCoordainte) => new MoveResult(lastCoordainte);
    }
}