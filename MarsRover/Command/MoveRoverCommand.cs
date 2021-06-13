using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Command
{
    public class MoveRoverCommand : ICommand
    {
        private readonly ISurface surface;
        private readonly List<MovementEnum> movementList;

        public MoveRoverCommand(ISurface surface, List<MovementEnum> movementList)
        {
            this.surface = surface;
            this.movementList = movementList;
        }

        public void Execute()
        {
            var roverToMove = this.surface.GetRovers().Last();
            List<Action> movementActions = this.CreateaMovementActions(this.movementList, roverToMove);
            roverToMove.ProcessMovementActions(movementActions);

            if (!this.surface.IsValidPosition(roverToMove.GetPosition()))
                throw new Exception($"Rover left the field. LastSeen: {roverToMove.GetPosition().XCoordinate} {roverToMove.GetPosition().YCoordinate} {roverToMove.GetDirection().ReportString}");
        }


        private List<Action> CreateaMovementActions(List<MovementEnum> moves, IRover rover)
        {
            List<Action> actionList = new List<Action>();

            foreach (var movement in moves)
            {
                switch (movement)
                {
                    case MovementEnum.Left:
                        actionList.Add(rover.SpinLeft);
                        break;
                    case MovementEnum.Right:
                        actionList.Add(rover.SpinRight);
                        break;
                    case MovementEnum.Forward:
                        actionList.Add(rover.MoveForward);
                        break;
                    default:
                        break;
                }
            }

            return actionList;

        }
    }
}