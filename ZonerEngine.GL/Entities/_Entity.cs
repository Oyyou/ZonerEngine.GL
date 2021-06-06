using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Components;

namespace ZonerEngine.GL.Entities
{
  public class Entity
  {
    public readonly List<Entity> Entities = new List<Entity>();

    public readonly List<Component> Components = new List<Component>();

    public Vector2 Position { get; set; }

    public bool IsRemoved { get; set; } = false;

    public float Layer { get; set; }

    public string Tag { get; set; }

    public Entity()
    {

    }

    public virtual void LoadContent()
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

      foreach (var entity in Entities)
        entity.Update(gameTime, entities);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      foreach (var component in Components)
        component.Draw(gameTime, spriteBatch);

      foreach (var entity in Entities)
        entity.Draw(gameTime, spriteBatch);
    }

    public void AddComponent(Component component)
    {
      Components.Add(component);
    }

    public void AddEntities(params Entity[] entities)
    {
      foreach (var entity in entities)
        AddEntity(entity);
    }

    public void AddEntity(Entity entity)
    {
      Entities.Add(entity);
    }
  }
}
