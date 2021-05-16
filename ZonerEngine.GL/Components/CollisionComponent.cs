using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public enum CollisionTypes
  {
    Static,
    Dynamic,
  }

  public class CollisionComponent : Component
  {
    private readonly Texture2D _border;

    private Rectangle _rectangle;

    private readonly Func<Rectangle> _getRectangle;

    /// <summary>
    /// Where the rectangle is when applying the parent position;
    /// </summary>
    public Rectangle CollisionRectangle { get; private set; }

    public readonly CollisionTypes CollisionType;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent">The entity with the collision</param>
    /// <param name="rectangle">The rectangle relative to the entity</param>
    public CollisionComponent(Entity parent, Rectangle rectangle, CollisionTypes collisionType) : this(parent, () => rectangle, collisionType)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent">The entity with the collision</param>
    /// <param name="rectangle">The rectangle relative to the entity</param>
    public CollisionComponent(Entity parent, Func<Rectangle> getRectangle, CollisionTypes collisionType) : base(parent)
    {
      _getRectangle = getRectangle;
      CollisionType = collisionType;
      UpdateCollisionRectangle();

      if (Helpers.IsDebug())
        _border = ZonerGame.TextureManager.GetRectangleBorder(_rectangle);
    }

    public override void Unload()
    {
      _border.Dispose();
    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
      UpdateCollisionRectangle();
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (_border != null && ZonerGame.Settings.ShowCollidingBoxes)
        spriteBatch.Draw(_border, CollisionRectangle, null, Color.White, 0f, new Vector2(0f, 0f), SpriteEffects.None, 0.99f);
    }

    private void UpdateCollisionRectangle()
    {
      _rectangle = _getRectangle();
      CollisionRectangle = new Rectangle(
        (int)Parent.Position.X + _rectangle.X,
        (int)Parent.Position.Y + _rectangle.Y,
        _rectangle.Width,
        _rectangle.Height);
    }

    public Rectangle GetRectangleWithVelocity(Vector2 velocity)
    {
      return new Rectangle(
        CollisionRectangle.X + (int)velocity.X,
        CollisionRectangle.Y + (int)velocity.Y,
        CollisionRectangle.Width,
        CollisionRectangle.Height
      );
    }
  }
}
