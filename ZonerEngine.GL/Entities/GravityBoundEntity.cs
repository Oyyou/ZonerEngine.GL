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
    public enum PlayerStates
    {
      Idle,
      Running,
      Jumping,
      Falling,
      WallJumping,
    }

    private TextureComponent _textureComponent;
    private MoveComponent _moveComponent;
    private CollisionComponent _collisionComponent;

    public PlayerStates State { get; private set; } = PlayerStates.Idle;

    public GravityBoundEntity(Texture2D texture, Vector2 position)
    {
      Position = position;

      _textureComponent = new TextureComponent(this, texture)
      {
        Colour = Color.Green,
      };
      _moveComponent = new MoveComponent(this, (gameTime, entities) => Move(gameTime, entities));
      _collisionComponent = new CollisionComponent(this, new Rectangle(
        0,
        0,
        texture.Width,
        texture.Height),
        CollisionTypes.All
      );

      AddComponent(_textureComponent);
      AddComponent(_moveComponent);
      AddComponent(_collisionComponent);
    }

    private float _fall;
    private float _jump;

    private bool _falling = false;
    private bool _jumping = false;
    private bool _wallJumping = false;
    private bool _onGround = false;
    private bool _onWall = false;
    private float _wallJumpDirection = 0;

    private float _wallJumpTimer = 0f;
    private float _wallJumpSpeed = 0f;

    public enum GravityStates
    {
      //Jumping,
      //Falling,
      //OnGround,
    }

    //private GravityStates _gravityState = GravityStates.Falling;

    private void Move(GameTime gameTime, List<Entity> entities)
    {
      PlayerStates nextState = PlayerStates.Idle;
      bool jump = false;
      if (GameKeyboard.IsKeyDown(Keys.A) || GameKeyboard.IsKeyDown(Keys.D))
      {
        nextState = PlayerStates.Running;
      }

      if (GameKeyboard.IsKeyDown(Keys.Space) && !_wallJumping)
      {
        if (_onGround)
        {
          jump = true;
        }
        else
        {
          if (_onWall && _falling)
          {
            jump = true;
            _wallJumping = true;
          }
        }
      }

      var velocity = new Vector2();
      _moveComponent.Velocity = new Vector2();

      var speed = 3f;

      if (!_wallJumping)
      {
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
      }

      if (jump)
      {
        _jumping = true;
        _jump = -10f;
        //_gravityState = GravityStates.Jumping;
      }

      if (_jumping)
      {
        _jump += 0.5f;
        _fall = 0;
        velocity.Y += _jump;
        if (_jump >= 0)
        {
          _jumping = false;
          //_gravityState = GravityStates.Falling;
        }
      }

      if (!_jumping && !_wallJumping)
      {
        _fall += 0.5f;
        _fall = MathHelper.Clamp(_fall, 0, 10);
        velocity.Y += _fall;
      }

      if (_wallJumping)
      {
        _wallJumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (!_jumping)
        {
          _wallJumpTimer = 0;
          _wallJumping = false;
          _jumping = false;
        }

        velocity.X += (5f * _wallJumpDirection);
      }

      _onGround = false;
      _onWall = false;
      _falling = false;
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

        if (doneY && y == 0)
          _onGround = true;

        if (doneX && x == 0)
        {
          _onWall = true;
          _wallJumping = false;
          if (entityCollisionRectangle.Left > originalCollisionRectangle.Left)
            _wallJumpDirection = -1f;
          else _wallJumpDirection = 1f;
        }
      }

      if (_onGround)
      {
        _fall = 0;
      }
      else if (velocity.Y > 0)
      {
        //_gravityState = GravityStates.Falling;
        _falling = true;
      }

      _moveComponent.Velocity = velocity;
    }
  }
}
