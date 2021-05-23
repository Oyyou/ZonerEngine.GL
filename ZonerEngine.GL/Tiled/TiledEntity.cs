using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZonerEngine.GL.Components;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Tiled
{
  public class TiledEntity : Entity
  {
    protected readonly Vector2 _position;
    protected readonly Texture2D _texture;

    protected List<Rectangle> _sourceRectangles;

    public SpriteEffects SpriteEffect = SpriteEffects.None;

    public TiledEntity(Texture2D texture, Vector2 position, Rectangle? sourceRectangle = null)
      : this(texture, position, sourceRectangle.HasValue ? new Rectangle[] { sourceRectangle.Value } : new Rectangle[] { })
    {
    }

    public TiledEntity(Texture2D texture, Vector2 position, params Rectangle[] sourceRectangles)
    {
      _texture = texture;
      _position = position;
      _sourceRectangles = sourceRectangles
        .OrderBy(c => c.X)
        .ThenBy(c => c.Y)
        .ToList();
    }

    public override void LoadContent()
    {
      Position = _position;

      if (_sourceRectangles.Count > 0)
      {
        var firstRect = _sourceRectangles.First();
        var firstRecPosition = new Vector2(firstRect.X, firstRect.Y);
        foreach (var rectangle in _sourceRectangles)
        {
          var offset = firstRecPosition + new Vector2(rectangle.X, rectangle.Y);

          var textureComponent = new TextureComponent(this, _texture)
          {
            Layer = Layer,
            SpriteEffect = SpriteEffect,
          };
          textureComponent.SourceRectangle = rectangle;

          AddComponent(textureComponent);
        }
      }
      else
      {
        var textureComponent = new TextureComponent(this, _texture)
        {
          Layer = Layer,
          SpriteEffect = SpriteEffect,
        };

        AddComponent(textureComponent);
      }
    }
  }
}
