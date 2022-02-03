﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Components;

namespace ZonerEngine.GL.Entities
{
  public class Entity : ICloneable, IClickable
  {
    public List<Entity> Entities { get; protected set; } = new List<Entity>();

    public List<Component> Components { get; protected set; } = new List<Component>();

    public Vector2 Position { get; set; }

    public bool IsRemoved { get; set; } = false;

    public float Layer { get; set; }

    public float ClickLayer => Layer;

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

      foreach (var entity in Entities)
        entity.Unload();

      Entities.Clear();
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

    public object Clone()
    {
      var result = (Entity)this.MemberwiseClone();
      result.Entities = this.Entities.ToList();
      result.Components = this.Components.ToList();
      result.Entities.Clear();
      result.Components.Clear();

      foreach (var entity in Entities)
      {
        var newEntity = (Entity)entity.Clone();
        result.Entities.Add(newEntity);
      }

      foreach (var component in Components)
      {
        var newComponent = (Component)component.Clone();
        newComponent.Parent = result;
        result.Components.Add(newComponent);
      }

      return result;
    }
  }
}
