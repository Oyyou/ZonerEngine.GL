using System;
using Microsoft.Xna.Framework;
using ZonerEngine.GL.Input;

namespace ZonerEngine.GL.Cameras
{
  public class Camera
  {
    public Vector2 Position;
    public Matrix Transform { get; set; }

    public int? MinX { get; set; }

    public int? MinY { get; set; }

    public int? MaxX { get; set; }

    public int? MaxY { get; set; }

    public float Scale { get; set; } = 1f;

    public Camera(Vector2 position)
    {
      Position = position;
    }

    public Camera()
    {

    }

    public void Follow(Vector2 followPosition)
    {
      var newPosition = followPosition;

      //newPosition.X = CheckNSet(newPosition.X, MinX);
      //newPosition.Y = CheckNSet(newPosition.Y, MinY);
      //newPosition.X = CheckNSet(newPosition.X, MaxX);
      //newPosition.Y = CheckNSet(newPosition.Y, MaxY);

      if (GameKeyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
        Scale += 0.01f;
      else if (GameKeyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
        Scale -= 0.01f;

      //Scale = 1.57f;// Math.Clamp(Scale, 0.5f, 2.0f);

      Position = newPosition;// Vector2.Lerp(Position, newPosition, 0.05f);
      //Transform = Matrix.CreateTranslation(Position.X, Position.Y, 0);v
      var x = -Position.X + (ZonerGame.ScreenWidth / 2);
      var y = -Position.Y + (ZonerGame.ScreenHeight / 2);

      if (x > 0)
        x = 0;
      //if (y > -260 )
      //  y = -260;

      Transform = Matrix.CreateTranslation(x, y, 0) * 
        Matrix.CreateScale(Scale, Scale, 1);
    }

    public void Update()
    {
      if (GameKeyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
        Position.X--;
      else if (GameKeyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
        Position.X++;

      if (GameKeyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
        Position.Y++;
      else if (GameKeyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
        Position.Y--;

    }

    private float CheckNSet(float value, int? nextValue)
    {
      var newValue = value;

      if (nextValue.HasValue && value < nextValue.Value)
        newValue = nextValue.Value;

      return newValue;
    }
  }
}
