﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
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

    public static bool NearlyEqual(float f1, float f2)
    {
      // Equal if they are within 0.00001 of each other
      return Math.Abs(f1 - f2) < 0.00001;
    }

    public static bool NearlyEqual(Vector2 v1, Vector2 v2)
    {
      return NearlyEqual(v1.X, v2.X) && NearlyEqual(v1.Y, v2.Y);
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

    public static Rectangle Divide(this Rectangle rect, int amount)
    {
      return new Rectangle(
        rect.X / amount,
        rect.Y / amount,
        rect.Width / amount,
        rect.Height / amount);
    }
    public static Rectangle Multiply(this Rectangle rect, int amount)
    {
      return new Rectangle(
        rect.X * amount,
        rect.Y * amount,
        rect.Width * amount,
        rect.Height * amount);
    }

    public static Rectangle ToRectangle(this Vector2 position, int width, int height)
    {
      return new Rectangle(
        (int)position.X,
        (int)position.Y,
        width,
        height);
    }

    public static Point Multiply(this Point point, int amount)
    {
      return new Point(point.X * amount, point.Y * amount);
    }

    public static Matrix CreateScale(this Matrix m, float x, float y, float z)
    {
      m.M11 = x;
      m.M22 = y;
      m.M33 = z;
      m.M44 = 1f;
      return m;
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

    public static Dictionary<T1, T2> ToDictionary<T1, T2>(this object obj)
    {
      return JObject.FromObject(obj).ToObject<Dictionary<T1, T2>>();
    }

    public static Color[] GetBorder(Texture2D texture, int thickness = 1, Color? colour = null, Color? fillColour = null)
    {
      return GetBorder(texture.Width, texture.Height, thickness, colour, fillColour);
    }

    public static Color[] GetBorder(int width, int height, int thickness = 1, Color? colour = null, Color? fillColour = null)
    {
      thickness = Math.Max(1, thickness);

      var colours = new Color[width * height];

      var index = 0;
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          var newColour = fillColour != null ? fillColour.Value : new Color(0, 0, 0, 0);

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
