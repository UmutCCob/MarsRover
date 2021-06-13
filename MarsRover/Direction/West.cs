using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Direction
{
    public class West : ICardinalDirection
    {
        public string ReportString
        {
            get
            {
                return "W";
            }
        }
        public void MoveForward(Rover rover)
        {
            var position = rover.GetPosition();
            position.SetXPosition(position.XCoordinate - 1);
        }

        public ICardinalDirection SpinLeft()
        {
            return new South();
        }

        public ICardinalDirection SpinRight()
        {
            return new North();
        }
    }
}
