using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ZonerEngine.GL.Input
{
  public static class GameKeyboard
  {
    public static KeyboardState CurrentKeyboard;
    public static KeyboardState PreviouseKeyboard;

    private static Dictionary<Keys, float> _keyTimer = new Dictionary<Keys, float>();

    public static void Update(GameTime gameTime)
    {
      PreviouseKeyboard = CurrentKeyboard;
      CurrentKeyboard = Keyboard.GetState();

      foreach (var key in CurrentKeyboard.GetPressedKeys())
      {
        if (!_keyTimer.ContainsKey(key))
        {
          _keyTimer.Add(key, 0);
        }

        if (_keyTimer[key] < 10) // max of 10s
          _keyTimer[key] += (float)gameTime.ElapsedGameTime.TotalSeconds;
      }

      for (int i = 0; i < _keyTimer.Count; i++)
      {
        var key = _keyTimer.ElementAt(i).Key;

        if (CurrentKeyboard.IsKeyUp(key))
          _keyTimer[key] = 0;
      }
    }

    public static bool IsKeyDown(Keys key)
    {
      return CurrentKeyboard.IsKeyDown(key);// && _keyTimer[key] > 0.1;
    }

    public static bool IsKeyUp(Keys key)
    {
      return CurrentKeyboard.IsKeyUp(key);// && _keyTimer[key] > 0.1;
    }

    public static bool WasKeyDown(Keys key)
    {
      return PreviouseKeyboard.IsKeyDown(key);
    }

    public static bool WasKeyUp(Keys key)
    {
      return PreviouseKeyboard.IsKeyUp(key);
    }

    public static bool IsKeyPressed(Keys key)
    {
      return PreviouseKeyboard.IsKeyDown(key) &&
        CurrentKeyboard.IsKeyUp(key);
    }
  }
}
