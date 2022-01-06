using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Maps;

namespace ZonerEngine.GL.Entities
{
  public class MappableEntity : Entity, IMappableObject
  {
    public bool IsSolid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Rectangle Rectangle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
}
