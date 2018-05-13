using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Rover.Tests
{
    [TestFixture]
    public class PositionShould
    {
        [TestCaseSource(nameof(MoveForwardTestCases))]
        [TestCaseSource(nameof(WrapForwardTestCases))]
        public void Change_When_Moving_Forward(Position position, Coordinate expectedNextCoordinate)
        {
            position.Forward().Coordinate.Should().BeEquivalentTo(expectedNextCoordinate);
        }

        [TestCaseSource(nameof(MoveBackwardTestCases))]
        [TestCaseSource(nameof(WrapBackwardTestCases))]
        public void Change_When_Moving_Backward(Position position, Coordinate expectedNextCoordinate)
        {
            position.Backward().Coordinate.Should().BeEquivalentTo(expectedNextCoordinate);
        }

        [TestCaseSource(nameof(TurnLeftTestCases))]
        public void Change_Direction_When_Turning_Left(Position position, Coordinate expectedNextCoordinate)
        {
            position.TurnLeft().Coordinate.Should().BeEquivalentTo(expectedNextCoordinate);
        }

        [TestCaseSource(nameof(TurnRightTestCases))]
        public void Change_Direction_When_Turning_Right(Position position, Coordinate expectedNextCoordinate)
        {
            position.TurnRight().Coordinate.Should().BeEquivalentTo(expectedNextCoordinate);
        }

        private static IPlanet Planet => new Planet(5, 5);

        private static IEnumerable<TestCaseData> MoveForwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.North, Planet), new Coordinate(new Point(1, 2), Direction.North));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.South, Planet), new Coordinate(new Point(1, 0), Direction.South));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.East, Planet), new Coordinate(new Point(2, 1), Direction.East));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.West, Planet), new Coordinate(new Point(0, 1), Direction.West));
            }
        }

        private static IEnumerable<TestCaseData> MoveBackwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.North, Planet), new Coordinate(new Point(1, 0), Direction.North));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.South, Planet), new Coordinate(new Point(1, 2), Direction.South));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.East, Planet), new Coordinate(new Point(0, 1), Direction.East));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.West, Planet), new Coordinate(new Point(2, 1), Direction.West));
            }
        }

        private static IEnumerable<TestCaseData> TurnLeftTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North, Planet), new Coordinate(new Point(0, 0), Direction.West));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South, Planet), new Coordinate(new Point(0, 0), Direction.East));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East, Planet), new Coordinate(new Point(0, 0), Direction.North));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West, Planet), new Coordinate(new Point(0, 0), Direction.South));
            }
        }

        private static IEnumerable<TestCaseData> TurnRightTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North, Planet), new Coordinate(new Point(0, 0), Direction.East));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South, Planet), new Coordinate(new Point(0, 0), Direction.West));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East, Planet), new Coordinate(new Point(0, 0), Direction.South));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West, Planet), new Coordinate(new Point(0, 0), Direction.North));
            }
        }

        private static IEnumerable<TestCaseData> WrapForwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 4), Direction.North, Planet), new Coordinate(new Point(0, 0), Direction.North));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South, Planet), new Coordinate(new Point(0, 4), Direction.South));
                yield return new TestCaseData(new Position(new Point(4, 0), Direction.East, Planet), new Coordinate(new Point(0, 0), Direction.East));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West, Planet), new Coordinate(new Point(4, 0), Direction.West));
            }
        }

        private static IEnumerable<TestCaseData> WrapBackwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North, Planet), new Coordinate(new Point(0, 4), Direction.North));
                yield return new TestCaseData(new Position(new Point(0, 4), Direction.South, Planet), new Coordinate(new Point(0, 0), Direction.South));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East, Planet), new Coordinate(new Point(4, 0), Direction.East));
                yield return new TestCaseData(new Position(new Point(4, 0), Direction.West, Planet), new Coordinate(new Point(0, 0), Direction.West));
            }
        }
    }
}