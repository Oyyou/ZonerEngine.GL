using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Entities;

namespace ZonerEngine.GL.Components
{
  public enum TriggerStatus
  {
    Idle,
    Active,
    Complete
  }

  public class TriggerComponent : Component
  {
    private Func<bool> _triggerEvent;

    private Func<bool> _onTrigger;

    public TriggerStatus Status { get; private set; } = TriggerStatus.Idle;

    public TriggerComponent(Entity parent, Func<bool> triggerEvent, Func<bool> onTrigger) : base(parent)
    {
      _triggerEvent = triggerEvent;
      _onTrigger = onTrigger;
    }

    public override void Unload()
    {

    }

    public override void Update(GameTime gameTime, List<Entity> entities)
    {
      if (Status == TriggerStatus.Complete)
        return;

      if (_triggerEvent())
        Status = TriggerStatus.Active;

      if (Status == TriggerStatus.Active && _onTrigger())
        Status = TriggerStatus.Complete;
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
