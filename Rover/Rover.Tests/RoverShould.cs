using FluentAssertions;
using NUnit.Framework;

namespace Rover.Tests
{
    [TestFixture]
    public class RoverShould
    {
        private IPlanet _planet;
        private IRover _rover;

        [SetUp]
        public void SetUp()
        {
            _planet = new Planet(5, 5);
            _rover = new Rover(_planet);
        }

        [Test]
        public void Have_Start_Coordainte()
        {
            // Arrange
            var expectedCorrdinate = new Coordainte(new Point(0, 0), Direction.North);

            // Assert
            _rover.Coordinate.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Move_Forward_And_Backward()
        {
            // Arrange
            const string commands = "FFFBBBF";
            var expectedCorrdinate = new Coordainte(new Point(0, 1), Direction.North);

            // Act
            var moveResult = _rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Turn_Left()
        {
            // Arrange
            const string commands = "LL";
            var expectedCorrdinate = new Coordainte(new Point(0, 0), Direction.South);

            // Act
            var moveResult = _rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Turn_Right()
        {
            // Arrange
            const string commands = "RRR";
            var expectedCorrdinate = new Coordainte(new Point(0, 0), Direction.West);

            // Act
            var moveResult = _rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Bypass_A_Planet()
        {
            // Arrange
            const string commands = "RFLFFFFF";
            var expectedCorrdinate = new Coordainte(new Point(1, 0), Direction.North);

            // Act
            var moveResult = _rover.Move(commands);

            // Assert
            moveResult.LastCoordainte.Should().BeEquivalentTo(expectedCorrdinate);
        }
    }
}
