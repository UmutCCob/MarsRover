using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests
{
    public class SurfaceTests
    {
        private readonly Surface sut;

        public SurfaceTests()
        {
            this.sut = new Surface();
        }

        [Fact]
        public void IsValidPosition_Returns_False_When_Position_IsInvalid()
        {
            //Arrange
            this.sut.SetSize(new Size(5, 5));
            var invalidPosition = new Position(6, 7);

            //Act
            bool result = this.sut.IsValidPosition(invalidPosition);

            //Assert
            Assert.False(result);
        }
    }
}
