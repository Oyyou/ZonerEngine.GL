using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Entities;
using ZonerEngine.GL.Models;

namespace ZonerEngine.GL.States
{
  public class DefaultState : State
  {
    private List<Entity> _entities;

    public DefaultState(GameModel gameModel) : base(gameModel)
    {
    }

    public override void LoadContent()
    {
    }

    public override void UnloadContent()
    {
      foreach (var entity in _entities)
        entity.Unload();

      _entities.Clear();
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var entity in _entities)
        entity.Update(gameTime, _entities);
    }

    public override void Draw(GameTime gameTime)
    {
      _spriteBatch.Begin();

      foreach (var entity in _entities)
        entity.Draw(gameTime, _spriteBatch);

      _spriteBatch.End();
    }
  }
}
