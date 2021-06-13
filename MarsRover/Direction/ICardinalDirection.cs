using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Direction
{
    public interface ICardinalDirection
    {
        string ReportString { get; }
        ICardinalDirection SpinLeft();
        ICardinalDirection SpinRight();
        void MoveForward(Rover rover);
    }
}
