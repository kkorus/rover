using FluentAssertions;
using NUnit.Framework;

namespace Rover.Tests
{
    [TestFixture]
    public class RoverShould
    {
        [Test]
        public void Have_Start_Coordainte()
        {
            // Arrange
            var rover = new Rover();
            var expectedCorrdinate = new Coordainte(new Point(0, 0), Direction.North);

            // Assert
            rover.Coordinate.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Move_Forward_And_Backward()
        {
            // Arrange
            var rover = new Rover();
            const string commands = "FFFBBBF";
            var expectedCorrdinate = new Coordainte(0, 1, Direction.North);

            // Act
            var moveResult = rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }
    }
}
