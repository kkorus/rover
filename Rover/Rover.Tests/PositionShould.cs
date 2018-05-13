using FluentAssertions;
using NUnit.Framework;

namespace Rover.Tests
{
    [TestFixture]
    public class PositionShould
    {
        [Test]
        public void Change_When_Moving_Forward()
        {
            // Arrange
            var position = new Position(new Point(1, 1), Direction.North);
            var expectedEndPosition = new Position(new Point(1, 2), Direction.North);

            // Act
            var nextPosition = position.Forward();

            // Assert
            nextPosition.Should().BeEquivalentTo(expectedEndPosition);
        }

        [Test]
        public void Change_When_Moving_Backward()
        {
            // Arrange
            var position = new Position(new Point(1, 1), Direction.North);
            var expectedEndPosition = new Position(new Point(1, 0), Direction.North);

            // Act
            var nextPosition = position.Backward();

            // Assert
            nextPosition.Should().BeEquivalentTo(expectedEndPosition);
        }

        [Test]
        public void Change_Direction_When_Turining_Left()
        {
            // Arrange
            var position = new Position(new Point(0, 0), Direction.North);
            var expectedEndPosition = new Position(new Point(0, 0), Direction.West);

            // Act
            var nextPosition = position.TurnLeft();

            // Assert
            nextPosition.Should().BeEquivalentTo(expectedEndPosition);
        }

        [Test]
        public void Change_Direction_When_Turining_Right()
        {
            // Arrange
            var position = new Position(new Point(0, 0), Direction.North);
            var expectedEndPosition = new Position(new Point(0, 0), Direction.East);

            // Act
            var nextPosition = position.TurnRight();

            // Assert
            nextPosition.Should().BeEquivalentTo(expectedEndPosition);
        }
    }
}