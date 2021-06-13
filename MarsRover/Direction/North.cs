using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Direction
{
    public class North : ICardinalDirection
    {
        public string ReportString
        {
            get
            {
                return "N";
            }
        }

        public void MoveForward(Rover rover)
        {
            var position = rover.GetPosition();
            position.SetYPosition(position.YCoordinate + 1);
        }

        public ICardinalDirection SpinLeft()
        {
            return new West();
        }

        public ICardinalDirection SpinRight()
        {
            return new East();
        }
    }
}
