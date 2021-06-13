using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Direction
{
    public class East : ICardinalDirection
    {
        public string ReportString
        {
            get
            {
                return "E";
            }
        }
        public void MoveForward(Rover rover)
        {
            var position = rover.GetPosition();
            position.SetXPosition(position.XCoordinate + 1);
        }

        public ICardinalDirection SpinLeft()
        {
            return new North();
        }

        public ICardinalDirection SpinRight()
        {
            return new South();
        }
    }
}
