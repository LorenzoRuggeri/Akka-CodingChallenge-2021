using System;
using System.Collections.Generic;
using Akka.Models;
using Akka.Core;
using Akka.Core.Models;
using Akka.Core.Components;
using System.Linq;

namespace Akka.Main
{
  public class CustomComponent : AbstractTileProcessor
  {

    public override string TeamName => "Il nome del Team va qui!";

    public override void Calculate(IEnumerable<IWindow> input)
    {
      // La tua soluzione va qui!
    }

  }
}
