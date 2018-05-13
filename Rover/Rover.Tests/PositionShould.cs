using System.Collections.Generic;
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
            var expectedNextPosiiton = new Position(new Point(1, 2), Direction.North);

            // Act
            var nextPosition = position.Forward();

            // Assert
            nextPosition.Should().BeEquivalentTo(expectedNextPosiiton);
        }

        [Test]
        public void Change_When_Moving_Backward()
        {
            // Arrange
            var position = new Position(new Point(1, 1), Direction.North);
            var expectedNextPosiiton = new Position(new Point(1, 0), Direction.North);

            // Act
            var nextPosition = position.Backward();

            // Assert
            nextPosition.Should().BeEquivalentTo(expectedNextPosiiton);
        }

        [TestCaseSource(nameof(TurnLeftTestCases))]
        public void Change_Direction_When_Turning_Left(Position position, Position expectedNextPosiiton)
        {
            position.TurnLeft().Should().BeEquivalentTo(expectedNextPosiiton);
        }

        [TestCaseSource(nameof(TurnRightTestCases))]
        public void Change_Direction_When_Turning_Right(Position position, Position expectedNextPosiiton)
        {
            position.TurnRight().Should().BeEquivalentTo(expectedNextPosiiton);
        }

        public static IEnumerable<TestCaseData> TurnLeftTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North), new Position(new Point(0, 0), Direction.West));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South), new Position(new Point(0, 0), Direction.East));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East), new Position(new Point(0, 0), Direction.North));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West), new Position(new Point(0, 0), Direction.South));
            }
        }

        public static IEnumerable<TestCaseData> TurnRightTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North), new Position(new Point(0, 0), Direction.East));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South), new Position(new Point(0, 0), Direction.West));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East), new Position(new Point(0, 0), Direction.South));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West), new Position(new Point(0, 0), Direction.North));
            }
        }
    }
}