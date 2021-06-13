using MarsRover.Direction;
using MarsRover.Enum;
using MarsRover.Helper;
using MarsRover.Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{

    public class RoverTests
    {
        private readonly Rover sut;


        public RoverTests()
        {
            this.sut = new Rover();
        }

        [Theory]
        [InlineData(3, 4, CardinalDirectionEnum.East)]
        [InlineData(1, 2, CardinalDirectionEnum.South)]
        public void Deploy_Given_Valid_Values_Sets_The_Position_And_Direction(int X, int Y, CardinalDirectionEnum direction)
        {
            //Arrage
            Position validPosition = new Position(X, Y);
            ICardinalDirection cardinalDirection = DirectionHelper.GetDirection(direction);

            //Act
            this.sut.Deploy(validPosition, cardinalDirection);

            //Assert
            Assert.Equal(validPosition.XCoordinate, sut.position.XCoordinate);
            Assert.Equal(validPosition.YCoordinate, sut.position.YCoordinate);
            Assert.Equal(cardinalDirection, sut.direction);
        }

        [Fact]
        public void Move_Given_Valid_Values_Rover_Explores()
        {
            //Arrange
            Position validPosition = new Position(1, 1);
            ICardinalDirection cardinalDirection = new East();
            this.sut.Deploy(validPosition, cardinalDirection);

            List<Action> actions = new List<Action>
            {
                sut.SpinLeft,
                sut.MoveForward,
                sut.SpinRight
            };

            //Act
            this.sut.ProcessMovementActions(actions);

            //Assert
            Assert.Equal(2, sut.position.YCoordinate);
            Assert.Equal(1, sut.position.XCoordinate);
            Assert.IsType<East>(sut.direction);

        }
    }
}
