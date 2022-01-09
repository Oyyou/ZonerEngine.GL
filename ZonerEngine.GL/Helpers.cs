using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using ZonerEngine.GL.Components;
using ZonerEngine.GL.Entities;
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

    public static T GetComponent<T>(this Entity b) where T : Component
    {
      return b.Components.OfType<T>().FirstOrDefault() as T;
    }
    public static IEnumerable<T> GetComponents<T>(this Entity b) where T : Component
    {
      return b.Components.OfType<T>() as IEnumerable<T>;
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

    public static Color[] GetBorder(Texture2D texture, int thickness = 1, Color? colour = null)
    {
      return GetBorder(texture.Width, texture.Height, thickness, colour);
    }

    public static Color[] GetBorder(int width, int height, int thickness = 1, Color? colour = null)
    {
      thickness = Math.Max(1, thickness);

      var colours = new Color[width * height];

      var index = 0;
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          var newColour = new Color(0, 0, 0, 0);

          if (x < thickness || x > (width - 1) - thickness ||
              y < thickness || y > (height - 1) - thickness)
          {
            newColour = colour != null ? colour.Value : new Color(255, 255, 0, 10);
          }

          colours[index] = newColour;

          index++;
        }
      }

      return colours;
    }
  }
}
