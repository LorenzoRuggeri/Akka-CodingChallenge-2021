using System;
using System.Collections.Generic;
using System.Text;
using Akka.Core.Models;
using Akka.Models;

namespace Akka.Main.Tests.Data
{
  class MockData
  {
    private static Random rng = new Random();

    public IScreenResolution CreateScreenResolution()
    {
      return new ScreenResolutionDto(1024, 780);
    }

    public List<WindowDto> CreateWindows(IScreenResolution resolution)
    {
      return Randomize(16, 300, 200, resolution);
    }

    public List<WindowDto> CreateWindows(int numberOfWindows, IScreenResolution resolution)
    {
      return Randomize(numberOfWindows, 300, 200, resolution);
    }

    public List<WindowDto> CreateWindows(int numberOfWindows, int maxWidth, int maxHeight, IScreenResolution resolution)
    {
      return Randomize(numberOfWindows, maxWidth, maxHeight, resolution);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="numberOfwindows"></param>
    /// <param name="maxWidth"></param>
    /// <param name="maxHeight"></param>
    /// <returns></returns>
    /// <remarks>
    /// Possibilmente facciamo in modo che il <paramref name="maxHeight"/> e <paramref name="maxWidth"/> non siano piu' grandi
    /// della risoluzione del Desktop. :)
    /// </remarks>
    public static List<WindowDto> Randomize(int numberOfwindows,
      int maxWidth, int maxHeight,
      IScreenResolution resolution)
    {
      var result = new List<WindowDto>();

      for (int i = 1; i < numberOfwindows + 1; i++)
      {
        // Randomizziamo le dimensioni minime.
        var minWidthToRespect = rng.Next(maxWidth);
        var minHeightToRespect = rng.Next(maxHeight);

        var item = new WindowDto();

        item.ID = i;

        item.Width = rng.Next(minWidthToRespect, maxWidth);
        item.MinWidth = minWidthToRespect;
        item.Height = rng.Next(minHeightToRespect, maxHeight);
        item.MinHeight = minHeightToRespect;

        // Definisci il posizionamento.
        item.X = rng.Next(1, resolution.Width - item.Width);
        item.Y = rng.Next(1, resolution.Height - item.Height);

        // Aggiungi al risultato.
        result.Add(item);
      }

      return result;
    }
  }
}
