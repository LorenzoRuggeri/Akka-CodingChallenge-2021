using Akka.Core.Models;

namespace Akka.Models
{
  public class ScreenResolutionDto : IScreenResolution
  {
    public int Width { get; set; }
    public int Height { get; set; }

    public ScreenResolutionDto() { }

    public ScreenResolutionDto(int width, int height)
    {
      this.Width = width;
      this.Height = height;
    }
  }
}
