using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public abstract class Component : ICloneable
  {
    public Entity Parent { get; set; }

    public Component(Entity parent)
    {
      Parent = parent;
    }

    public abstract void Unload();

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    public abstract object Clone();
  }
}
