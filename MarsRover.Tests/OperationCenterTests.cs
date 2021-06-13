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
    public class OperationCenterTests
    {
        private readonly Mock<ICommandParser> mockCommandParser;
        private readonly Mock<ICommandFactory> mockCommandFactory;
        private readonly Mock<ISurface> mockSurface;
        private readonly OperationCenter sut;
        public OperationCenterTests()
        {
            this.mockCommandParser = new Mock<ICommandParser>();
            this.mockCommandFactory = new Mock<ICommandFactory>();
            this.mockSurface = new Mock<ISurface>();
            this.sut = new OperationCenter(mockCommandParser.Object, mockCommandFactory.Object, mockSurface.Object);
        }

        [Fact]
        public void CreateCommands_Returns_List_Of_ICommand_Given_Commandstrings_Valid()
        {
            //Arrange
            this.mockCommandParser.Setup(x => x.ParseCommands(It.IsAny<List<string>>())).Returns(new List<CommandModel>());
            this.mockCommandFactory.Setup(x => x.CreateCommands(It.IsAny<List<CommandModel>>())).Returns(new List<ICommand>()
            {
               new SurfaceSizeCommand(new Size(1,1), this.mockSurface.Object),

            });
            List<string> commandStrings = new List<string>
            {
                "1 1",
                "1 2 N",
                "LMLMLM"
            };

            //Act
            var commands = this.sut.CreateCommands(commandStrings);

            //Assert
            Assert.NotNull(commands);
            this.mockCommandParser.Verify(x => x.ParseCommands(It.IsAny<List<string>>()), Times.Once);
            this.mockCommandFactory.Verify(x => x.CreateCommands(It.IsAny<List<CommandModel>>()), Times.Once);
        }

    }
}
