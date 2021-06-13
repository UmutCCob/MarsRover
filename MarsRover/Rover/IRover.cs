using MarsRover.Direction;
using MarsRover.Model;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public interface IRover
    {
        void Deploy(Position position, ICardinalDirection direction);
        void SpinLeft();
        void SpinRight();
        void MoveForward();
        Position GetPosition();
        void ProcessMovementActions(List<Action> actions);
        string BroadcastPosition();
        ICardinalDirection GetDirection();
    }
}