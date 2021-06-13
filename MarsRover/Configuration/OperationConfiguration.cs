using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Configuration
{
    public class OperationConfiguration : IOperationConfiguration
    {

        private readonly IConfiguration configuration;

        public OperationConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string SurfaceLimits
        {
            get
            {
                return this.configuration.GetValue<string>("SurfaceLimits", string.Empty);
            }
        }

        public string[] RoverCoordinates
        {
            get
            {
                return this.configuration.GetSection("RoverCoordinates").GetChildren().Select(x => x.Value).ToArray();
            }
        }

        public string[] RoverCommands
        {
            get
            {
                return this.configuration.GetSection("RoverCommands").GetChildren().Select(x => x.Value).ToArray();
            }
        }
    }
}
