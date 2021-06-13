using MarsRover.Direction;
using MarsRover.Enum;
using MarsRover.Helper;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly ISurface surface;
        private readonly IRoverFactory roverFactory;

        public CommandFactory(ISurface surface, IRoverFactory roverFactory)
        {
            this.surface = surface;
            this.roverFactory = roverFactory;
        }

        public List<ICommand> CreateCommands(List<CommandModel> commands)
        {
            List<ICommand> commandList = new List<ICommand>();
            foreach (var command in commands)
            {
                switch (command.CommandType)
                {
                    case CommandType.SurfaceSizeCommand:

                        var sizeLimits = command.CommandString.Split(" ");
                        Size surfaceSize = new Size(Convert.ToInt32(sizeLimits[0]), Convert.ToInt32(sizeLimits[1]));
                        commandList.Add(new SurfaceSizeCommand(surfaceSize, this.surface));
                        break;

                    case CommandType.DeployRoverCommand:
                        var positionCoordinates = command.CommandString.Split(" ");
                        Position position = new Position(Convert.ToInt32(positionCoordinates[0]), Convert.ToInt32(positionCoordinates[1]));
                        CardinalDirectionEnum directionEnum = DirectionHelper.CardinalDirectionParser(positionCoordinates[2]);
                        ICardinalDirection direction = DirectionHelper.GetDirection(directionEnum);
                        commandList.Add(new DeployRoverCommand(this.roverFactory, this.surface, position, direction));
                        break;

                    case CommandType.MoveRoverCommand:
                        List<MovementEnum> movementList = MovementHelper.MovementParser(command.CommandString);
                        commandList.Add(new MoveRoverCommand(this.surface, movementList));
                        break;
                    default:
                        throw new Exception();
                }
            }
            return commandList;
        }
    }
}

