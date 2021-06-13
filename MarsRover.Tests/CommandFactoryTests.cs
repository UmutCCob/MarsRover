using MarsRover.Command;
using MarsRover.Enum;
using MarsRover.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests
{
    public class CommandFactoryTests
    {
        private readonly Mock<ISurface> mockSurface;
        private readonly Mock<IRoverFactory> mockRoverFactory;
        private readonly CommandFactory sut;

        public CommandFactoryTests()
        {
            this.mockSurface = new Mock<ISurface>();
            this.mockRoverFactory = new Mock<IRoverFactory>();
            this.sut = new CommandFactory(mockSurface.Object, mockRoverFactory.Object);
        }

        [Fact]
        public void CreateCommands_When_Given_Valid_Dictionary()
        {
            //Arrange
            List<CommandModel> commands = new List<CommandModel>
            {
                new CommandModel { CommandString = "5 5", CommandType = CommandType.SurfaceSizeCommand },
                new CommandModel{ CommandString = "1 2 N",CommandType = CommandType.DeployRoverCommand },
                new CommandModel{ CommandString ="LMLMLMLMLM", CommandType =CommandType.MoveRoverCommand }
            };

            //Act
            var commandList = this.sut.CreateCommands(commands);

            //Assert

            Assert.Equal(3, commandList.Count);
            Assert.IsType<SurfaceSizeCommand>(commandList[0]);
            Assert.IsType<DeployRoverCommand>(commandList[1]);
            Assert.IsType<MoveRoverCommand>(commandList[2]);
        }


    }
}
