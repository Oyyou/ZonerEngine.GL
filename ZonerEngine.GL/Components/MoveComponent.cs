using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public class MoveComponent : Component
  {
    private Action<GameTime> _move;

    public Vector2 Velocity;

    public MoveComponent(Entity parent, Action<GameTime> move) : base(parent)
    {
      _move = move;
    }

    public override void Unload()
    {

    }

    public override void Update(GameTime gameTime)
    {
      _move(gameTime);
      Parent.Position += Velocity;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    public override object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
