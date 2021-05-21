using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Components;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Tiled
{
  public class TiledEntity : Entity
  {
    protected readonly Vector2 _position;
    protected readonly Texture2D _texture;

    protected Rectangle? _sourceRectangle = null;

    public SpriteEffects SpriteEffect = SpriteEffects.None;

    public TiledEntity(Texture2D texture, Vector2 position, Rectangle? sourceRectangle = null)
    {
      _texture = texture;
      _position = position;
      _sourceRectangle = sourceRectangle;
    }

    public override void LoadContent()
    {
      Position = _position;

      var textureComponent = new TextureComponent(this, _texture)
      {
        Layer = Layer,
        SpriteEffect = SpriteEffect,
      };
      if (_sourceRectangle.HasValue)
        textureComponent.SourceRectangle = _sourceRectangle.Value;

      AddComponent(textureComponent);
    }
  }
}
