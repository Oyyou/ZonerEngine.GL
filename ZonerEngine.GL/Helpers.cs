using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ZonerEngine.GL.Components;
using ZonerEngine.GL.Tiled;

namespace ZonerEngine.GL
{
  public static class Helpers
  {
    public static bool IsDebug()
    {
#if DEBUG
      return true;
#endif
      return false;
    }

    public static T GetComponent<T>(this IEnumerable<Component> b) where T : Component
    {
      return b.OfType<T>().FirstOrDefault() as T;
    }
    public static IEnumerable<T> GetComponents<T>(this IEnumerable<Component> b) where T : Component
    {
      return b.OfType<T>() as IEnumerable<T>;
    }

    public static Rectangle ToRectangle(this TiledObject obj)
    {
      return new Rectangle(
        (int)obj.X,
        (int)obj.Y,
        (int)obj.Width,
        (int)obj.Height
      );
    }
  }
}
