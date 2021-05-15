using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZonerEngine.GL.Components;
using ZonerEngine.GL.Input;

namespace ZonerEngine.GL.Entities
{
  public class GravityBoundEntity : Entity
  {
    private TextureComponent _textureComponent;
    private MoveComponent _moveComponent;
    private CollisionComponent _collisionComponent;

    public GravityBoundEntity(Texture2D texture, Vector2 position)
    {
      Position = position;

      _textureComponent = new TextureComponent(this, texture);
      _moveComponent = new MoveComponent(this, (gameTime, entities) => Move(gameTime, entities));
      _collisionComponent = new CollisionComponent(this, new Rectangle(
        0,
        0,
        texture.Width,
        texture.Height),
        CollisionTypes.Dynamic
      );

      AddComponent(_textureComponent);
      AddComponent(_moveComponent);
      AddComponent(_collisionComponent);
    }

    private float _fall;
    private float _jump;

    public enum GravityStates
    {
      Jumping,
      Falling,
      OnGround,
    }

    private GravityStates _gravityState = GravityStates.Falling;

    private void Move(GameTime gameTime, List<Entity> entities)
    {
      var velocity = new Vector2();
      _moveComponent.Velocity = new Vector2();

      var speed = 3f;

      if (GameKeyboard.IsKeyDown(Keys.A))
      {
        velocity.X = -speed;
      }
      else if (GameKeyboard.IsKeyDown(Keys.D))
      {
        velocity.X = speed;
      }
      else
      {
        velocity.X = 0;
      }

      if (GameKeyboard.IsKeyDown(Keys.Space) && _gravityState == GravityStates.OnGround)
      {
        _jump = -10f;
        _gravityState = GravityStates.Jumping;
      }

      if (_gravityState == GravityStates.Jumping)
      {
        _jump += 0.5f;
        velocity.Y += _jump;
        if (_jump >= 0)
        {
          _gravityState = GravityStates.Falling;
        }
      }

      if (_gravityState != GravityStates.Jumping)
      {
        _fall += 0.5f;
        velocity.Y += _fall;
      }

      foreach (var entity in entities)
      {
        if (entity == this)
          continue;

        var entityCollision = entity.Components.FirstOrDefault(c => c is CollisionComponent) as CollisionComponent;
        if (entityCollision == null)
          continue;

        var nextRectangleX = _collisionComponent.GetRectangleWithVelocity(new Vector2((float)Math.Ceiling(velocity.X), 0));
        var nextRectangleY = _collisionComponent.GetRectangleWithVelocity(new Vector2(0, (float)Math.Ceiling(velocity.Y)));

        var originalCollisionRectangle = _collisionComponent.CollisionRectangle;
        var entityCollisionRectangle = entityCollision.CollisionRectangle;
        var x = velocity.X;
        var y = velocity.Y;
        var doneX = false;
        var doneY = false;
        if (nextRectangleX.Intersects(entityCollisionRectangle))
        {
          doneX = true;
          if (x > 0)
            x = -(originalCollisionRectangle.Right - entityCollisionRectangle.Left);
          else
            x = -(originalCollisionRectangle.Left - entityCollisionRectangle.Right);
        }

        if (nextRectangleY.Intersects(entityCollisionRectangle))
        {
          doneY = true;
          if (y > 0)
            y = -(originalCollisionRectangle.Bottom - entityCollisionRectangle.Top);
          else
            y = -(originalCollisionRectangle.Top - entityCollisionRectangle.Bottom);
        }

        if (doneX && doneY)
        {
          var newX = Math.Abs(x);
          var newY = Math.Abs(y);

          if (newX > newY)
            y = 0;
          else x = 0;
        }

        velocity = new Vector2(x, y);
      }

      if (velocity.Y == 0)
      {
        _fall = 0;
        _gravityState = GravityStates.OnGround;
      }
      else if (velocity.Y > 0)
      {
        _gravityState = GravityStates.Falling;
      }

      _moveComponent.Velocity = velocity;
    }
  }
}
