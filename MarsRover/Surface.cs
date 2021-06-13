using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Surface : ISurface
    {
        public Size Size { get; set; }
        public List<IRover> Rovers { get; set; }

        public Surface()
        {
            this.Size = new Size(0, 0);
            this.Rovers = new List<IRover>();
        }

        public void SetSize(Size size)
        {
            this.Size = size;
        }

        public void DeployOnSurface(IRover rover)
        {
            this.Rovers.Add(rover);
        }

        public bool IsValidPosition(Position position)
        {
            var xCheck = position.XCoordinate >= 0 && position.XCoordinate <= this.Size.Width;
            var yCheck = position.YCoordinate >= 0 && position.YCoordinate <= this.Size.Height;

            return xCheck && yCheck;
        }

        public List<IRover> GetRovers()
        {
            return this.Rovers;
        }

        public string ReportRovers()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var rover in Rovers)
            {
                builder.AppendLine(rover.BroadcastPosition());
            }
            return builder.ToString();
        }
    }
}
