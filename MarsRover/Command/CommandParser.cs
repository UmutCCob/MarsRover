using MarsRover.Enum;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Command
{
    public class CommandParser : ICommandParser
    {

        public List<CommandModel> ParseCommands(List<string> commands)
        {
            var commandTypeDictionary = this.CommandTypeRegexDictionary();
            var commandModelList = new List<CommandModel>();
            foreach (string command in commands)
            {
                var commandType = commandTypeDictionary.FirstOrDefault(x => new Regex(x.Key).IsMatch(command));
                if (commandType.Key == null)
                    throw new Exception($"Invalid command: {command}");
                commandModelList.Add(new CommandModel {CommandString = command, CommandType = commandType.Value });
            }

            this.ValidateCommandTypes(commandModelList);

            return commandModelList;
        }

        private Dictionary<string, CommandType> CommandTypeRegexDictionary()
        {
            return new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.SurfaceSizeCommand },
                { @"^\d+ \d+ [NSEW]$", CommandType.DeployRoverCommand},
                { @"^[LRM]+$", CommandType.MoveRoverCommand }
            };
        }

        private void ValidateCommandTypes(List<CommandModel> commands)
        {
            if (commands.Count(x => x.CommandType == CommandType.SurfaceSizeCommand) != 1)
                throw new Exception("There can only be one SurfaceSizeCommand");

            if (commands.Count(x => x.CommandType == CommandType.DeployRoverCommand) != commands.Count(x => x.CommandType == CommandType.MoveRoverCommand))
                throw new Exception("Count of DeployRoverCommand must be equal to count of MoveRoverCommand");

        }



    }
}
