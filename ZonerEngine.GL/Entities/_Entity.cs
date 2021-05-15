using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Components;

namespace ZonerEngine.GL.Entities
{
  public class Entity
  {
    public readonly List<Component> Components = new List<Component>();

    public Vector2 Position { get; set; }

    public Entity()
    {

    }

    public virtual void Unload()
    {
      foreach (var component in Components)
        component.Unload();

      Components.Clear();
    }

    public virtual void Update(GameTime gameTime, List<Entity> entities)
    {
      foreach (var component in Components)
        component.Update(gameTime, entities);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      foreach (var component in Components)
        component.Draw(gameTime, spriteBatch);
    }

    public void AddComponent(Component component)
    {
      Components.Add(component);
    }
  }
}
