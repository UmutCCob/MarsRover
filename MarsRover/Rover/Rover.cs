using MarsRover.Command;
using MarsRover.Direction;
using MarsRover.Enum;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover : IRover
    {
        public Position position;
        public ICardinalDirection direction;


        public Rover()
        {
        }

        public Position GetPosition()
        {
            return this.position;
        }

        public ICardinalDirection GetDirection()
        {
            return this.direction;
        }


        public void SpinLeft()
        {
            this.direction = this.direction.SpinLeft();
        }

        public void SpinRight()
        {
            this.direction = this.direction.SpinRight();
        }

        public void Deploy(Position position, ICardinalDirection direction)
        {
            this.position = position;
            this.direction = direction;
        }

        public void ProcessMovementActions(List<Action> actions)
        {
            foreach (var action in actions)
            {
                action.Invoke();
            }
        }

        public void MoveForward()
        {
            this.direction.MoveForward(this);
        }

        public string BroadcastPosition()
        {
            return $"{position.XCoordinate} {position.YCoordinate} {this.direction.ReportString}";
        }

    }
}
