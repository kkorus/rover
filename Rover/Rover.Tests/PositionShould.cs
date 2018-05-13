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
        public void Change_When_Moving_Forward(Position position, Position expectedNextPosiiton)
        {
            position.Forward().Should().BeEquivalentTo(expectedNextPosiiton);
        }

        [TestCaseSource(nameof(MoveBackwardTestCases))]
        [TestCaseSource(nameof(WrapBackwardTestCases))]
        public void Change_When_Moving_Backward(Position position, Position expectedNextPosiiton)
        {
            position.Backward().Should().BeEquivalentTo(expectedNextPosiiton);
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

        private static IPlanet Planet => new Planet(5, 5);

        private static IEnumerable<TestCaseData> MoveForwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.North, Planet), new Position(new Point(1, 2), Direction.North, Planet));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.South, Planet), new Position(new Point(1, 0), Direction.South, Planet));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.East, Planet), new Position(new Point(2, 1), Direction.East, Planet));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.West, Planet), new Position(new Point(0, 1), Direction.West, Planet));
            }
        }

        private static IEnumerable<TestCaseData> MoveBackwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.North, Planet), new Position(new Point(1, 0), Direction.North, Planet));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.South, Planet), new Position(new Point(1, 2), Direction.South, Planet));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.East, Planet), new Position(new Point(0, 1), Direction.East, Planet));
                yield return new TestCaseData(new Position(new Point(1, 1), Direction.West, Planet), new Position(new Point(2, 1), Direction.West, Planet));
            }
        }

        private static IEnumerable<TestCaseData> TurnLeftTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North, Planet), new Position(new Point(0, 0), Direction.West, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South, Planet), new Position(new Point(0, 0), Direction.East, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East, Planet), new Position(new Point(0, 0), Direction.North, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West, Planet), new Position(new Point(0, 0), Direction.South, Planet));
            }
        }

        private static IEnumerable<TestCaseData> TurnRightTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North, Planet), new Position(new Point(0, 0), Direction.East, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South, Planet), new Position(new Point(0, 0), Direction.West, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East, Planet), new Position(new Point(0, 0), Direction.South, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West, Planet), new Position(new Point(0, 0), Direction.North, Planet));
            }
        }

        private static IEnumerable<TestCaseData> WrapForwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 4), Direction.North, Planet), new Position(new Point(0, 0), Direction.North, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.South, Planet), new Position(new Point(0, 4), Direction.South, Planet));
                yield return new TestCaseData(new Position(new Point(4, 0), Direction.East, Planet), new Position(new Point(0, 0), Direction.East, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.West, Planet), new Position(new Point(4, 0), Direction.West, Planet));
            }
        }

        private static IEnumerable<TestCaseData> WrapBackwardTestCases
        {
            get
            {
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.North, Planet), new Position(new Point(0, 4), Direction.North, Planet));
                yield return new TestCaseData(new Position(new Point(0, 4), Direction.South, Planet), new Position(new Point(0, 0), Direction.South, Planet));
                yield return new TestCaseData(new Position(new Point(0, 0), Direction.East, Planet), new Position(new Point(4, 0), Direction.East, Planet));
                yield return new TestCaseData(new Position(new Point(4, 0), Direction.West, Planet), new Position(new Point(0, 0), Direction.West, Planet));
            }
        }
    }
}