using MarsRover.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IOperationCenter
    {
        IList<ICommand> CreateCommands(List<string> commandStrings);
    }
}
