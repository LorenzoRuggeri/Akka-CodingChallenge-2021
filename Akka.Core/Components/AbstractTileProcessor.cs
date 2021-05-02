using System;
using System.Collections.Generic;
using System.Text;
using Akka.Core.Models;

namespace Akka.Core.Components
{
  public abstract class AbstractTileProcessor : ITileProcessor
  {
    private IScreenResolution resolution;

    public int ScreenWidth
    { 
      get { return resolution?.Width ?? throw new ArgumentNullException(nameof(ScreenWidth)); }
    }

    public int ScreenHeight
    {
      get { return resolution?.Height ?? throw new ArgumentNullException(nameof(ScreenHeight)); }
    }

    public abstract string TeamName { get; }

    public void SetScreenResolution(IScreenResolution resolution)
    {
      if (resolution == null)
        throw new ArgumentNullException(nameof(resolution));
      if (resolution.Width == default)
        throw new ArgumentException(nameof(resolution.Width));
      if (resolution.Height == default)
        throw new ArgumentException(nameof(resolution.Height));

      this.resolution = resolution;
    }

    public abstract void Calculate(IEnumerable<IWindow> input);
  }
}
