using System;
using Microsoft.Xna.Framework;

namespace ZonerEngine.GL.Cameras
{
  public class Camera
  {
    public Vector2 Position { get; set; }
    public Matrix Transform { get; protected set; }

    public void Follow(Vector2 followPosition)
    {
      Position = Vector2.Lerp(Position, followPosition, 0.05f);
      Transform = Matrix.CreateTranslation(-Position.X + (ZonerGame.ScreenWidth / 2), 0, 0);
    }
  }
}
