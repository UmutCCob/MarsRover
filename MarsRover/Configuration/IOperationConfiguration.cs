using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Configuration
{
    public interface IOperationConfiguration
    {
        string SurfaceLimits { get; }
    
        string[] RoverCoordinates { get; }

        string[] RoverCommands { get; }
    
    }
}
