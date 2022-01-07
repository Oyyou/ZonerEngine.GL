using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZonerEngine.GL;
using ZonerEngine.GL.States;

namespace ZonerEngine.Testing
{
  public class Game1 : ZonerGame
  {

    public Game1()
    {

    }

    protected override void Initialize()
    {

      base.Initialize();
    }

    protected override void LoadContent()
    {
      _state = new TestingState(GameModel);
      _state.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
      _state.Update(gameTime);

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      _state.Draw(gameTime);

      base.Draw(gameTime);
    }
  }
}
