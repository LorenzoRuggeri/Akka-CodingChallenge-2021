using Akka.Core.Models;

namespace Akka.Models
{
  public class WindowDto : IWindow
  {
    public int ID { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public int MinWidth { get; set; }
    public int MinHeight { get; set; }

    public WindowDto() { }

    public WindowDto(IWindow window)
    {
      this.ID = window.ID;
      this.X = window.X;
      this.Y = window.Y;
      this.Width = window.Width;
      this.Height = window.Height;
      this.MinWidth = window.MinWidth;
      this.MinHeight = window.MinHeight;
    }

    public override string ToString()
    {
      return $"ID: {ID}, X: {X}, Y: {Y}, Width: {Width}, Height: {Height}";
    }
  }
}
