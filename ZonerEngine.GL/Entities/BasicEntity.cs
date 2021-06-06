using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Components;

namespace ZonerEngine.GL.Entities
{
  public class BasicEntity : Entity
  {
    public BasicEntity(Texture2D texture, Vector2 position)
    {
      Position = position;

      var textureComponent = new TextureComponent(this, texture);
      var collisionComponent = new CollisionComponent(this, new Rectangle(
        0,
        0,
        texture.Width,
        texture.Height),
        CollisionTypes.All
      );

      AddComponent(textureComponent);
      AddComponent(collisionComponent);
    }
  }
}
