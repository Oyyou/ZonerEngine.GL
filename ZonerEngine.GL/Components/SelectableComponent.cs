using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Entities;
using ZonerEngine.GL.Input;

namespace ZonerEngine.GL.Components
{
  public class SelectableComponent : Component
  {
    public Rectangle Rectangle { get; private set; }

    public Func<Rectangle> GetRectangle;

    public Action OnSelected;

    public Action OnHover;

    public Action OffSelected;

    public Action OffHover;

    public SelectableComponent(Entity parent, Rectangle staticRectangle) : base(parent)
    {
      Rectangle = staticRectangle;
    }

    public SelectableComponent(Entity parent, Func<Rectangle> getRectangle) : base(parent)
    {
      GetRectangle = getRectangle;
    }

    public override void Unload()
    {

    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
      if (GetRectangle != null)
        Rectangle = GetRectangle();

      if (GameMouse.Intersects(Rectangle))
      {
        OnHover?.Invoke();

        if (GameMouse.IsLeftClicked)
        {
          OnSelected?.Invoke();
        }
      }
      else
      {
        OffHover.Invoke();

        if (GameMouse.IsLeftClicked)
        {
          OffSelected?.Invoke();
        }
      }
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
