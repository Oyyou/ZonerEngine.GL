using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Input;
using ZonerEngine.GL.Managers;
using ZonerEngine.GL.Models;
using ZonerEngine.GL.States;

namespace ZonerEngine.GL
{
  public class ZonerGame : Game
  {
    protected GraphicsDeviceManager _graphics;
    protected SpriteBatch _spriteBatch;

    protected State _state;

    public GameModel GameModel { get; private set; }

    #region Statics

    public static Settings Settings;

    public static TextureManager TextureManager;
    public static Random Random;

    public static int ScreenWidth { get; protected set; }
    public static int ScreenHeight { get; protected set; }

    #endregion

    public ZonerGame()
    {
      Settings = new Settings();
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected void UpdateScreenResolution(int width, int height)
    {
      ScreenWidth = width;
      ScreenHeight = height;

      _graphics.PreferredBackBufferWidth = ScreenWidth;
      _graphics.PreferredBackBufferHeight = ScreenHeight;
      _graphics.ApplyChanges();
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      UpdateScreenResolution(1280, 720);
      Random = new Random();
      _spriteBatch = new SpriteBatch(GraphicsDevice);
      TextureManager = new TextureManager(_graphics.GraphicsDevice);
      GameModel = new GameModel(_graphics, Content, _spriteBatch);

      //TargetElapsedTime = TimeSpan.FromTicks((long)(TimeSpan.TicksPerSecond / 144));


      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      // Create a new SpriteBatch, which can be used to draw textures.
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      base.Update(gameTime);

      GameKeyboard.Update(gameTime);
      GameMouse.Update(gameTime);

      if(GameKeyboard.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.G))
      {
        Settings.ShowCollidingBoxes = !Settings.ShowCollidingBoxes;
      }
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);
    }
  }
}
