using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ZonerEngine.GL.Entities;
using ZonerEngine.GL.Maps;
using ZonerEngine.GL.Models;
using ZonerEngine.GL.States;

namespace ZonerEngine.Testing
{
  public class TestingState : State
  {
    private List<Entity> _entities;

    public TestingState(GameModel gameModel) : base(gameModel)
    {
    }

    public override void LoadContent()
    {
      var map = new Map(new char[,]
      {
        { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', },
      });

      map.Add(new GL.Components.MappedComponent(null, '#', () => new Rectangle(1, 0, 2, 2)));
      map.Add(new GL.Components.MappedComponent(null, '#', () => new Rectangle(1, 3, 2, 3)));
      map.Add(new GL.Components.MappedComponent(null, '#', () => new Rectangle(4, 2, 2, 2)));

      Pathfinder pf = new Pathfinder(map);
      var path = pf.GetPath(new System.Drawing.Point(0, 0), new System.Drawing.Point(5, 5));

      map.WriteMap();


      foreach (var point in path)
      {
        map.Add(new GL.Components.MappedComponent(null, '1', () => new Rectangle(point.X, point.Y, 1, 1)));
      }

      map.WriteMap();

      //map.Add(new GL.Components.MappedComponent(null, () => new Rectangle(-1, -1, 2, 2)));
      //map.Add(new GL.Components.MappedComponent(null, () => new Rectangle(1, 1, 2, 2)));
      //map.Add(new GL.Components.MappedComponent(null, () => new Rectangle(3, 3, 2, 2)));
      //map.Add(new GL.Components.MappedComponent(null, () => new Rectangle(6, 3, 2, 2)));
      //map.Add(new GL.Components.MappedComponent(null, () => new Rectangle(9, 3, 2, 2)));

      map.WriteMap();

      _entities = new List<Entity>();
    }

    public override void UnloadContent()
    {
      foreach (var entity in _entities)
        entity.Unload();

      _entities.Clear();
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var entity in _entities)
        entity.Update(gameTime, _entities);
    }

    public override void Draw(GameTime gameTime)
    {
      _spriteBatch.Begin();

      foreach (var entity in _entities)
        entity.Draw(gameTime, _spriteBatch);

      _spriteBatch.End();
    }
  }
}