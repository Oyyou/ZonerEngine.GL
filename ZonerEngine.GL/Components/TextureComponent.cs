using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public class TextureComponent : Component
  {
    protected Texture2D _texture;

    public Vector2 PositionOffset { get; set; } = new Vector2(0, 0);

    public float Layer { get; set; } = 0;

    public virtual int Width
    {
      get
      {
        return _texture.Width;
      }
    }

    public virtual int Height
    {
      get
      {
        return _texture.Height;
      }
    }

    public virtual Rectangle SourceRectangle
    {
      get
      {
        return new Rectangle(
          0,
          0,
          Width,
          Height);
      }
    }

    public SpriteEffects SpriteEffect = SpriteEffects.None;

    public Vector2 Origin { get; set; } = new Vector2(0, 0);

    public TextureComponent(Entity parent, Texture2D texture) : base(parent)
    {
      _texture = texture;
    }

    public override void Unload()
    {
      _texture.Dispose();
    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(_texture, Parent.Position + PositionOffset, SourceRectangle, Color.White, 0f, Origin, new Vector2(1, 1), SpriteEffect, Layer);
    }
  }
}
