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

    protected Func<bool> _drawCondition = () => true;

    protected bool _canDraw = true;

    public Vector2 PositionOffset { get; set; } = new Vector2(0, 0);

    public float Layer { get; set; } = 0;

    public Func<float> GetLayer = null;

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

    public Color Colour { get; set; } = Color.White;

    public float Opacity { get; set; } = 1f;

    public Rectangle SourceRectangle;

    public SpriteEffects SpriteEffect = SpriteEffects.None;

    public Vector2 Origin { get; set; } = new Vector2(0, 0);

    public Vector2 DrawPosition
    {
      get
      {
        return Parent.Position + PositionOffset;
      }
    }

    public TextureComponent(Entity parent, Texture2D texture, Func<bool> drawCondition = null) : base(parent)
    {
      _texture = texture;
      if (drawCondition != null)
        _drawCondition = drawCondition;
      SourceRectangle = new Rectangle(0, 0, Width, Height);
    }

    public override void Unload()
    {
      _texture.Dispose();
    }

    public override void Update(GameTime gameTime)
    {
      _canDraw = _drawCondition();
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (_canDraw)
      {
        if (GetLayer != null)
          Layer = GetLayer();

        spriteBatch.Draw(_texture, DrawPosition, SourceRectangle, Colour * Opacity, 0f, Origin, new Vector2(1, 1), SpriteEffect, Layer);
      }
    }

    public override object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
