using System;

namespace Rover
{
    public class InvalidMoveCommandException : Exception
    {
        public InvalidMoveCommandException(string message) : base(message)
        {
        }
    }
}