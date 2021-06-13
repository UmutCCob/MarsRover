using MarsRover.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class OperationCenter : IOperationCenter
    {
        private readonly ICommandParser commandParser;
        private readonly ICommandFactory commandFactory;
        private readonly ISurface surface;
        public OperationCenter(ICommandParser commandParser, ICommandFactory commandFactory, ISurface surface)
        {
            this.commandParser = commandParser;
            this.commandFactory = commandFactory;
            this.surface = surface;
        }

        public IList<ICommand> CreateCommands(List<string> commandStrings)
        {
            var parsedCommands = this.commandParser.ParseCommands(commandStrings);
            var commands = this.commandFactory.CreateCommands(parsedCommands);
            return commands;
        }

        public void ExecuteCommands(IList<ICommand> commands)
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }

        public string BroadcastResults()
        {
            return this.surface.ReportRovers();
        }


    }
}
