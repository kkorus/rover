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
    }
}
