using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;
using ZonerEngine.GL.Models;

namespace ZonerEngine.GL.Components
{
  public class AnimationComponent : Component
  {
    private float _timer;

    public bool Playing;

    public Action<GameTime> SetAnimation { get; set; }

    public Dictionary<string, Animation> Animations { get; private set; } = new Dictionary<string, Animation>();

    public Animation CurrentAnimation;

    public Vector2 Origin { get; set; } = new Vector2(0, 0);

    public SpriteEffects SpriteEffect = SpriteEffects.None;

    public float Layer { get; set; } = 0;

    public AnimationComponent(Entity parent) : base(parent)
    {
      Playing = true;
    }

    public void AddAnimation(string name, Animation animation)
    {
      if (Animations.ContainsKey(name))
        return;

      Animations.Add(name, animation);

      if (CurrentAnimation == null)
      {
        CurrentAnimation = animation;
        Origin = new Vector2((CurrentAnimation.Width / 2), 0);
      }
    }

    public void PlayAnimation(string name)
    {
      var nextAnimation = Animations[name];

      if (nextAnimation == CurrentAnimation)
        return;

      CurrentAnimation = nextAnimation;
      CurrentAnimation.CurrentFrame = 0;
      Origin = new Vector2((CurrentAnimation.Width / 2), 0);
    }

    public Rectangle SourceRectangle
    {
      get
      {
        return new Rectangle(
          CurrentAnimation.CurrentFrame * Width,
          0,
          Width,
          Height);
      }
    }

    public int Width
    {
      get
      {
        return CurrentAnimation.Width;
      }
    }

    public int Height
    {
      get
      {
        return CurrentAnimation.Height;
      }
    }

    public override void Unload()
    {
    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
      SetAnimation(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (!Playing)
      {
        CurrentAnimation.CurrentFrame = 0;
      }
      else
      {
        _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_timer >= CurrentAnimation.AnimationSpeed)
        {
          _timer = 0;
          CurrentAnimation.CurrentFrame++;

          if (CurrentAnimation.CurrentFrame >= CurrentAnimation.TotalXFrames)
            CurrentAnimation.CurrentFrame = 0;
        }
      }

      spriteBatch.Draw(CurrentAnimation.Texture, Parent.Position, SourceRectangle, Color.White, 0f, Origin, new Vector2(1, 1), SpriteEffect, Layer);
    }

    public override object Clone()
    {
      var result = (AnimationComponent)this.MemberwiseClone();
      result.CurrentAnimation = (Animation)this.CurrentAnimation.Clone();
      result.Animations = new Dictionary<string, Animation>();
      foreach(var animation in this.Animations)
      {
        result.AddAnimation(animation.Key, (Animation)animation.Value.Clone());
      }

      return result;
    }
  }
}
