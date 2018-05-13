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
            var expectedCorrdinate = new Coordainte(new Point(0, 1), Direction.North);

            // Act
            var moveResult = rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Turn_Left()
        {
            // Arrange
            var rover = new Rover();
            const string commands = "LL";
            var expectedCorrdinate = new Coordainte(new Point(0, 0), Direction.South);

            // Act
            var moveResult = rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Turn_Right()
        {
            // Arrange
            var rover = new Rover();
            const string commands = "RRR";
            var expectedCorrdinate = new Coordainte(new Point(0, 0), Direction.West);

            // Act
            var moveResult = rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Bypass_A_Planet()
        {
            // Arrange
            var planet = new Planet(5, 5);
            var rover = new Rover(planet);
            const string commands = "RFLFFFFF";
            var expectedCorrdinate = new Coordainte(new Point(1, 0), Direction.North);

            // Act
            var moveResult = rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }
    }
}
