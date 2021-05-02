using System;
using System.Collections.Generic;
using System.Text;

namespace Akka.Core.Models
{
  public static class ModelsExtensions
  {
    /// <summary>
    /// Determina se interseca con <paramref name="window"/>.
    /// </summary>
    /// <param name="self"></param>
    /// <param name="window"></param>
    /// <returns>
    /// <see langword="true"/> se la finestra interseca.
    /// </returns>
    public static bool IntersectsWith(this IWindow self, IWindow window)
    {
      return (window.X < self.X + self.Width) &&
            (self.X < (window.X + window.Width)) &&
            (window.Y < self.Y + self.Height) &&
            (self.Y < window.Y + window.Height);
    }

    /// <summary>
    /// Restringe l'area della finestra ai requisiti minimi imposti dalle 
    /// proprietà <see cref="IWindow.MinWidth"/> e <see cref="IWindow.MinHeight"/>.
    /// </summary>
    /// <param name="self"></param>
    public static void Shrink(this IWindow self)
    {
      self.Width = self.MinWidth;
      self.Height = self.MinHeight;
    }

    /// <summary>
    /// Calcola l'area della finestra.
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static int Area(this IWindow self)
    {
      return self.Width * self.Height;
    }

    public static int Right(this IWindow self)
    {
      return unchecked(self.X + self.Width);
    }

    public static int Bottom(this IWindow self)
    {
      return unchecked(self.Y + self.Height);
    }
  }
}
