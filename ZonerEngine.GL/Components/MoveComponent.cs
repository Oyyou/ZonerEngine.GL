using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public class MoveComponent : Component
  {
    private Action<GameTime, List<Entity>> _move;

    public Vector2 Velocity;

    public MoveComponent(Entity parent, Action<GameTime, List<Entity>> move) : base(parent)
    {
      _move = move;
    }

    public override void Unload()
    {

    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
      _move(gameTime, entities);
      Parent.Position += Velocity;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }
  }
}
