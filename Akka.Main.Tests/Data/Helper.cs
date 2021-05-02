using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akka.Models;

namespace Akka.Main.Tests.Data
{
  static class Helper
  {
    /// <remarks>
    /// Evitiamo il ToList e lo facciamo direttamente dentro il metodo.
    /// </remarks>
    public static List<WindowDto> DeepCopy(IEnumerable<WindowDto> input)
    {
      return input.Select(x => new WindowDto(x)).ToList();
    }
  }
}
