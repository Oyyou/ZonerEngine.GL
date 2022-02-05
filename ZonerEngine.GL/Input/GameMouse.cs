using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ZonerEngine.GL.Input
{
  public static class GameMouse
  {
    private static MouseState _currentMouse;
    private static MouseState _previouseMouse;

    #region IClickable related
    /// <summary>
    /// These are objects the mouse is currently hovering over
    /// </summary>
    public static List<IClickable> ClickableObjects = new List<IClickable>();

    /// <summary>
    /// The single object we're able to click
    /// </summary>
    public static IClickable ValidObject
    {
      get
      {
        return ClickableObjects.OrderBy(c => c.ClickLayer).LastOrDefault();
      }
    }

    public static void AddObject(IClickable clickableObject)
    {
      if (!ClickableObjects.Contains(clickableObject))
        ClickableObjects.Add(clickableObject);
    }
    #endregion

    public static bool IsLeftClicked
    {
      get
      {
        return _previouseMouse.LeftButton == ButtonState.Pressed &&
          _currentMouse.LeftButton == ButtonState.Released;
      }
    }

    public static bool IsLeftPressed
    {
      get
      {
        return _currentMouse.LeftButton == ButtonState.Pressed;
      }
    }

    public static bool IsRightPressed
    {
      get
      {
        return _currentMouse.RightButton == ButtonState.Pressed;
      }
    }

    public static bool IsRightClicked
    {
      get
      {
        return _previouseMouse.RightButton == ButtonState.Pressed &&
          _currentMouse.RightButton == ButtonState.Released;
      }
    }

    public static bool IsLeftReleased
    {
      get
      {
        return _currentMouse.LeftButton == ButtonState.Released;
      }
    }

    public static bool IsInWindow(int width, int height)
    {
      return X >= 0 && X <= width &&
        Y >= 0 && Y <= height;
    }

    public static Point Position
    {
      get
      {
        return _currentMouse.Position;
      }
    }

    public static Rectangle Rectangle
    {
      get
      {
        return new Rectangle(X, Y, 1, 1);
      }
    }

    public static int ScrollWheelValue
    {
      get
      {
        return _currentMouse.ScrollWheelValue;
      }
    }

    public static int X
    {
      get
      {
        return Position.X;
      }
    }

    public static int Y
    {
      get
      {
        return Position.Y;
      }
    }

    public static void Update(GameTime gameTime)
    {
      _previouseMouse = _currentMouse;
      _currentMouse = Mouse.GetState();
    }

    public static bool Intersects(Rectangle rectangle)
    {
      return Rectangle.Intersects(rectangle);
    }
  }
}
