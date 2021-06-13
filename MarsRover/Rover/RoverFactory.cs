using MarsRover.Direction;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverFactory : IRoverFactory
    {
        public IRover CreateRover()
        {
            return new Rover();
        }
    }
}
