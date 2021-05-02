using System;
using System.Linq;
using Akka.Core.Components;
using Akka.Core.Models;
using Akka.Main.Tests.Data;
using NUnit.Framework;

namespace Akka.Main.Tests
{
  [Category("Akka Pre-made")]
  public class BehaviourTest
  {
    private ITileProcessor sut;
    private MockData mock;
    private IScreenResolution resolution;

    [SetUp]
    public void Setup()
    {
      mock = new MockData();
      resolution = mock.CreateScreenResolution();

      sut = new CustomComponent();
      sut.SetScreenResolution(resolution);
    }


    [Test(Description = "Le finestre occupano una superficie pari a quella del desktop")]
    public void AreasOfWindowsEqualsAreaOfDesktop()
    {
      // ARRANGE
      var input = mock.CreateWindows(resolution);
      var output = Helper.DeepCopy(input);

      // ACT
      sut.Calculate(output);

      // ASSERT
      Assert.NotNull(output);

      var areaOfWindows = output
        .Select(window => window.Area())
        .Sum();

      var areaOfDesktop = sut.ScreenHeight * sut.ScreenWidth;

      Assert.AreEqual(areaOfDesktop, areaOfWindows);
    }


    [Test(Description = "Le finestre non si sovvrapongono")]
    public void WindowsDontOverlap()
    {
      // ARRANGE
      var input = mock.CreateWindows(resolution);
      var output = Helper.DeepCopy(input);

      // ACT
      sut.Calculate(output);

      // ASSERT
      Assert.NotNull(output);

      for (var i = 0; i < output.Count; i++)
      {
        var windowA = output[i];
        for (var j = i + 1; j < output.Count; j++)
        {
          var windowB = output[j];
          Assert.IsFalse(windowA.IntersectsWith(windowB), "La finestra '{0}' si sovvrapone alla finestra '{1}'", windowA.ID, windowB.ID);
        }
      }
    }


    [Test(Description = "Le finestre sono contenute all'interno del desktop")]
    public void WindowsAreOnScreen()
    {
      // ARRANGE
      var input = mock.CreateWindows(resolution);
      var output = Helper.DeepCopy(input);

      // ACT
      sut.Calculate(output);

      // ASSERT
      Assert.NotNull(output);

      foreach (var window in output)
      {
        Assert.Multiple(() =>
        {
          Assert.IsTrue(window.X >= 0 && window.X + window.Width <= sut.ScreenWidth, "La finestra '0' oltrepassa i limiti dello schermo.", window.ID);
          Assert.IsTrue(window.Y >= 0 && window.Y + window.Height <= sut.ScreenHeight, "La finestra '0' oltrepassa i limiti dello schermo.", window.ID);
        });
      }
    }


    // COMMENT: Questo deve essere verde fin dal principio. Altrimenti abbiamo un comportamento non voluto nei Mock.
    [Test(Description = "Le finestre date in input sono ritornate nell'output e le condizioni per la visualizzazione sono rispettate")]
    public void WindowsAreFormerlyValid()
    {
      // ARRANGE
      var input = mock.CreateWindows(resolution);
      var output = Helper.DeepCopy(input);

      // ACT
      sut.Calculate(output);

      // ASSERT
      Assert.NotNull(output);
      Assert.AreEqual(input.Count, output.Count, "Il numero delle finestre non e' equivalente");

      foreach (var inputWindow in input)
      {
        Assert.Multiple(() =>
        {
          Assert.Contains(inputWindow.ID, output.Select(x => x.ID).ToArray(), "La finestra con ID '{0}' non esiste nell'output.", inputWindow.ID);
          var window = input.First(x => x.ID == inputWindow.ID);
          Assert.AreEqual(inputWindow.MinHeight, window.MinHeight, "La finestra con ID '{0}' non rispecchia la proprietà {1} iniziale.", window.ID, nameof(window.MinHeight));
          Assert.AreEqual(inputWindow.MinWidth, window.MinWidth, "La finestra con ID '{0}' non rispecchia la proprietà {1} iniziale.", window.ID, nameof(window.MinWidth));
          Assert.LessOrEqual(window.MinWidth, window.Width);
          Assert.LessOrEqual(window.MinHeight, window.Height);
        });
      }
    }

  }
}