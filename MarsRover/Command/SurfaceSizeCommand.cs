using MarsRover.Model;

namespace MarsRover.Command
{
    public class SurfaceSizeCommand : ICommand
    {

        private readonly ISurface surface;
        private readonly Size size;
        public SurfaceSizeCommand(Size size, ISurface surface)
        {
            this.size = size;
            this.surface = surface;
        }

        public void Execute()
        {
            this.surface.SetSize(this.size);
        }
    }
}