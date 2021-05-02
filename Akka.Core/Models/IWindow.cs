namespace Akka.Core.Models
{
  public interface IWindow
  {
    int ID { get; }
    int Width { get; set; }
    int Height { get; set; }
    int X { get; set; }
    int Y { get; set; }
    int MinWidth { get; }
    int MinHeight { get; }
  }
}