using MarsRover.Enum;
using MarsRover.Model;
using System.Collections.Generic;

namespace MarsRover.Command
{
    public interface ICommandParser
    {
        List<CommandModel> ParseCommands(List<string> commands);
    }
}