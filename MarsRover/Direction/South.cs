using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Direction
{
    public class South : ICardinalDirection
    {
        public string ReportString
        {
            get
            {
                return "S";
            }
        }
        public void MoveForward(Rover rover)
        {
            var position = rover.GetPosition();
            position.SetYPosition(position.YCoordinate - 1);
        }

        public ICardinalDirection SpinLeft()
        {
            return new East();
        }

        public ICardinalDirection SpinRight()
        {
            return new West();
        }
    }
}
