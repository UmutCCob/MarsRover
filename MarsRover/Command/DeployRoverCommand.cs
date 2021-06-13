using MarsRover.Direction;
using MarsRover.Model;
using System;

namespace MarsRover.Command
{
    public class DeployRoverCommand : ICommand
    {
        private readonly IRoverFactory roverFactory;
        private readonly Position position;
        private readonly ICardinalDirection direction;
        private readonly ISurface surface;

        public DeployRoverCommand(IRoverFactory roverFactory, ISurface surface, Position position, ICardinalDirection direction)
        {
            this.roverFactory = roverFactory;
            this.position = position;
            this.direction = direction;
            this.surface = surface;
        }

        public void Execute()
        {
            if (this.surface.IsValidPosition(this.position))
            {
                var rover = roverFactory.CreateRover();
                rover.Deploy(position, direction);
                this.surface.DeployOnSurface(rover);
            }
            else
            {
                throw new Exception("Invalid position to deploy");
            }

        }
    }
}