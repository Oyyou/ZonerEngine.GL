using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Entities;
using ZonerEngine.GL.Input;
using ZonerEngine.GL.Models;

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

    public bool IsSelected { get; set; } = false;

    public bool IsHover { get; set; } = false;

    public EntityInformation Information { get; set; } = null;

    public Func<EntityInformation> GetInformation = null;

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
      if (GetInformation != null)
        Information = GetInformation();

      if (GetRectangle != null)
        Rectangle = GetRectangle();

      if (GameMouse.Intersects(Rectangle))
      {
        OnHover?.Invoke();
        IsHover = true;

        if (GameMouse.IsLeftClicked)
        {
          OnSelected?.Invoke();
          IsSelected = true;
        }
      }
      else
      {
        OffHover.Invoke();
        IsHover = false;

        if (GameMouse.IsLeftClicked && !GameKeyboard.IsKeyDown(Keys.LeftShift))
        {
          OffSelected?.Invoke();
          IsSelected = false;
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

