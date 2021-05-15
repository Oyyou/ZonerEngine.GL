using System;
using Microsoft.Xna.Framework.Graphics;

namespace ZonerEngine.GL.Models
{
  public class Animation
  {
    public readonly Texture2D Texture;

    public readonly int TotalXFrames;

    public readonly float AnimationSpeed;

    public int CurrentFrame;

    public int Width
    {
      get
      {
        return Texture.Width / TotalXFrames;
      }
    }

    public int Height
    {
      get
      {
        return Texture.Height;
      }
    }

    public Animation(Texture2D texture, int totalXFrames, float animationSpeed)
    {
      Texture = texture;
      TotalXFrames = totalXFrames;
      AnimationSpeed = animationSpeed;
    }
  }
}
