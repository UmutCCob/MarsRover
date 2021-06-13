using MarsRover.Enum;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface ICommandFactory
    {
        List<ICommand> CreateCommands(List<CommandModel> commands);
    }
}
