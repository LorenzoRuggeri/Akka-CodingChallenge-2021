using System.Collections.Generic;
using Akka.Core.Models;

namespace Akka.Core.Components
{
  public interface ITileProcessor
  {
    /// <summary>
    /// La larghezza del desktop sul quale si andrà ad operare.
    /// </summary>
    int ScreenWidth { get; }

    /// <summary>
    /// L'altezza del desktop sul quale si andrà ad operare.
    /// </summary>
    int ScreenHeight { get; }

    /// <summary>
    /// Il nome del Team impegnato nella Code-Challenge.
    /// </summary>
    string TeamName { get; }

    /// <summary>
    /// Processa una lista (<paramref name="input"/>) di <see cref="IWindow"/> per
    /// ottenere un tiling in base alla risoluzione dello schermo.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    void Calculate(IEnumerable<IWindow> input);

    /// <summary>
    /// Imposta la risoluzione dello schermo.
    /// </summary>
    /// <param name="resolution"></param>
    void SetScreenResolution(IScreenResolution resolution);
  }
}