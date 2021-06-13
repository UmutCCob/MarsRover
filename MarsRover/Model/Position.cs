using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model
{
    public class Position
    {
        public int XCoordinate;
        public int YCoordinate;

        public Position(int X, int Y)
        {
            this.XCoordinate = X;
            this.YCoordinate = Y;
        }



        public void SetYPosition(int Y)
        {
            this.YCoordinate = Y;
        }

        public void SetXPosition(int X)
        {
            this.XCoordinate = X;
        }
    }
}
