using MarsRover.Direction;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IRoverFactory
    {
        IRover CreateRover();
    }
}
