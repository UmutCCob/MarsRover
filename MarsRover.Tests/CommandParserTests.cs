using MarsRover.Command;
using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests
{
    public class CommandParserTests
    {
        private readonly CommandParser sut;
        public CommandParserTests()
        {
            this.sut = new CommandParser();
        }

        [Fact]
        public void ParseCommands_Returns_String_Enum_Dictionary_Given_CommandString_Is_Valid()
        {
            //Arrange
            List<string> commandStrings = new List<string>
            {
                "5 5",
                "1 1 N",
                "LMLMLMLMMR",
                "4 4 S",
                "LMLMLMLM"
            };

            //Act
            var commandList = this.sut.ParseCommands(commandStrings);

            //Assert
            Assert.NotNull(commandList);
            Assert.Equal(5, commandList.Count);
            Assert.Contains(commandList, x => x.CommandType == CommandType.DeployRoverCommand);
            Assert.Contains(commandList, x => x.CommandType == CommandType.SurfaceSizeCommand);
            Assert.Contains(commandList, x => x.CommandType == CommandType.MoveRoverCommand);
        }

        [Fact]
        public void ParseCommands_Throws_Exception_Given_CommandString_Is_Not_Valid()
        {
            //Arrange
            List<string> commandStrings = new List<string>
            {
                "5",
                "1 1 N",
                "LAMLMLMLMMR",
                "4 4 S",
                "LMLMLMLM"
            };

            //Act&Assert
            Assert.Throws<Exception>(() => sut.ParseCommands(commandStrings));


        }
    }
}
