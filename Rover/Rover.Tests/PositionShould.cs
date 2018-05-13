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
    }
}