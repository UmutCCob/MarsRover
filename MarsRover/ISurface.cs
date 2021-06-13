using MarsRover.Model;
using System.Collections.Generic;

namespace MarsRover
{
    public interface ISurface
    {
        void DeployOnSurface(IRover rover);
        void SetSize(Size size);

        string ReportRovers();
        List<IRover> GetRovers();
        bool IsValidPosition(Position position);
    }
}