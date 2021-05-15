using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Models;

namespace ZonerEngine.GL.States
{
  public abstract class State
  {
    protected SpriteBatch _spriteBatch
    {
      get
      {
        return GameModel.SpriteBatch;
      }
    }

    protected ContentManager _content
    {
      get
      {
        return GameModel.Content;
      }
    }

    public readonly GameModel GameModel;

    public State(GameModel gameModel)
    {
      GameModel = gameModel;
    }

    public abstract void Update(GameTime gameTime);

    public abstract void LoadContent();

    public abstract void UnloadContent();

    public abstract void Draw(GameTime gameTime);
  }
}
