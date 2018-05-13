using System;
using System.Collections.Generic;
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
            var expectedCorrdinate = new Coordinate(new Point(0, 0), Direction.North);

            // Assert
            _rover.Coordinate.Should().BeEquivalentTo(expectedCorrdinate);
        }

        [Test]
        public void Move_Forward_And_Backward()
        {
            // Arrange
            const string commands = "FFFBBBF";
            var expectedCorrdinate = new Coordinate(new Point(0, 1), Direction.North);

            AssertRoverPosition(commands, expectedCorrdinate);
        }

        [Test]
        public void Turn_Left()
        {
            // Arrange
            const string commands = "LL";
            var expectedCorrdinate = new Coordinate(new Point(0, 0), Direction.South);

            AssertRoverPosition(commands, expectedCorrdinate);
        }

        [Test]
        public void Turn_Right()
        {
            // Arrange
            const string commands = "RRR";
            var expectedCorrdinate = new Coordinate(new Point(0, 0), Direction.West);

            AssertRoverPosition(commands, expectedCorrdinate);
        }

        [Test]
        public void Bypass_A_Planet()
        {
            // Arrange
            const string commands = "RFLFFFFF";
            var expectedCorrdinate = new Coordinate(new Point(1, 0), Direction.North);

            AssertRoverPosition(commands, expectedCorrdinate);
        }

        [Test]
        public void Detect_Obstacles()
        {
            // Arrange
            _planet = new Planet(5, 5, new List<Point> { new Point(0, 1), new Point(1, 1) });
            _rover = new Rover(_planet);

            const string commands = "RFLFLFRF";
            var expectedObstaclesPoint = new Point(1, 1);

            // Act
            var moveResult = _rover.Move(commands);

            // Assert
            Assert.True(moveResult.ObstacleDetected);
            Assert.True(moveResult.ObstaclePoint.HasValue);
            moveResult.ObstaclePoint.Should().BeEquivalentTo(expectedObstaclesPoint);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\n")]
        [TestCase(null)]
        public void Throw_An_Exception_When_No_Commands_Given(string emptyCommands)
        {
            Assert.Throws<ArgumentException>(() => _rover.Move(emptyCommands));
        }

        [Test]
        public void Throw_An_Exception_When_Invalid_Command_Given()
        {
            const string invalidCommands = "FFF_XXX";

            Assert.Throws<InvalidMoveCommandException>(() => _rover.Move(invalidCommands));
        }

        private void AssertRoverPosition(string commands, Coordinate expectedCoordinate)
        {
            // Act
            var moveResult = _rover.Move(commands);

            // Assert
            moveResult.LastCoordinate.Should().BeEquivalentTo(expectedCoordinate);
        }
    }
}
