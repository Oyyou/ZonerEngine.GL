using System;
using Microsoft.Xna.Framework;

namespace ZonerEngine.GL.Cameras
{
  public class Camera
  {
    public Vector2 Position { get; set; }
    public Matrix Transform { get; set; }

    public int? MinX { get; set; }

    public int? MinY { get; set; }

    public int? MaxX { get; set; }

    public int? MaxY { get; set; }

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

      Position = Vector2.Lerp(Position, newPosition, 0.05f);
      Transform = Matrix.CreateTranslation(Position.X, Position.Y, 0);
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
