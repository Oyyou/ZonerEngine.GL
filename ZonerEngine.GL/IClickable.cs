using Microsoft.Xna.Framework;
using System;
namespace ZonerEngine.GL
{
  public interface IClickable
  {
    Rectangle ClickRectangle { get; }

    float ClickLayer { get; }

    bool ClickIsVisible { get; }
  }
}
