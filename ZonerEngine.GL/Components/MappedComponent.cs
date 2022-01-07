using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public class MappedComponent : Component
  {
    private Func<Rectangle> _getRectangle;

    public bool IsSolid { get; set; }

    public Rectangle Rectangle { get; set; }

    #region Properties

    public int X
    {
      get
      {
        return Rectangle.X;
      }
    }

    public int Y
    {
      get
      {
        return Rectangle.Y;
      }
    }

    public int Width
    {
      get
      {
        return Rectangle.Width;
      }
    }

    public int Height
    {
      get
      {
        return Rectangle.Height;
      }
    }

    public int Right
    {
      get
      {
        return Rectangle.Right;
      }
    }

    public int Bottom
    {
      get
      {
        return Rectangle.Bottom;
      }
    }

    #endregion

    public MappedComponent(Entity parent, Func<Rectangle> getRectangle) : base(parent)
    {
      _getRectangle = getRectangle;
      Rectangle = _getRectangle();
    }

    public override void Unload()
    {

    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
      Rectangle = _getRectangle();
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }
  }
}
