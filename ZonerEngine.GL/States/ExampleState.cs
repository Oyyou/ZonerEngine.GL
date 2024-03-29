﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZonerEngine.GL.Entities;
using ZonerEngine.GL.Models;

namespace ZonerEngine.GL.States
{
  public class ExampleState : State
  {
    private List<Entity> _entities;

    public ExampleState(GameModel gameModel) : base(gameModel)
    {
    }

    public override void LoadContent()
    {
      var block = ZonerGame.TextureManager.GetBlock(40, 40, Color.White);

      _entities = new List<Entity>();
      //_entities.Add(new BasicEntity(Content.Load<Texture2D>("Block"), new Vector2(60, 100)));
      //_entities.Add(new BasicEntity(Content.Load<Texture2D>("Block"), new Vector2(100, 100)));
      //_entities.Add(new BasicEntity(Content.Load<Texture2D>("Block"), new Vector2(160, 100)));
      _entities.Add(new GravityBoundEntity(block, new Vector2(200, 100)));
      //_entities.Add(new BasicEntity(Content.Load<Texture2D>("Block"), new Vector2(60, 300)));
      //_entities.Add(new BasicEntity(Content.Load<Texture2D>("Block"), new Vector2(100, 300)));
      _entities.Add(new BasicEntity(block, new Vector2(160, 0)));
      _entities.Add(new BasicEntity(block, new Vector2(160, 40)));
      _entities.Add(new BasicEntity(block, new Vector2(160, 80)));
      _entities.Add(new BasicEntity(block, new Vector2(160, 120)));
      _entities.Add(new BasicEntity(block, new Vector2(160, 160)));
      _entities.Add(new BasicEntity(block, new Vector2(160, 200)));

      _entities.Add(new BasicEntity(block, new Vector2(200, 320)));
      _entities.Add(new BasicEntity(block, new Vector2(240, 320)));
      _entities.Add(new BasicEntity(block, new Vector2(280, 320)));
      _entities.Add(new BasicEntity(block, new Vector2(320, 320)));

      _entities.Add(new BasicEntity(block, new Vector2(360, 0)));
      _entities.Add(new BasicEntity(block, new Vector2(360, 40)));
      _entities.Add(new BasicEntity(block, new Vector2(360, 80)));
      _entities.Add(new BasicEntity(block, new Vector2(360, 120)));
      _entities.Add(new BasicEntity(block, new Vector2(360, 160)));
      _entities.Add(new BasicEntity(block, new Vector2(360, 200)));
      //var rectangles = new Dictionary<Vector2, List<Rectangle>>();
      //var otherRects = new List<List<Rectangle>>();
      //foreach (var entity in _entities)
      //{
      //  var collisionComponent = entity.Components.GetComponent<CollisionComponent>();
      //  if (collisionComponent == null)
      //    continue;

      //  if (collisionComponent.CollisionType != CollisionTypes.Static)
      //    continue;

      //  var rectangle = collisionComponent.CollisionRectangle;

      //  foreach(var rects in otherRects)
      //  {
      //    foreach(var rect in rects)
      //    {
      //      if(rect.Contains(rect))
      //      {

      //      }
      //    }
      //  }

      //  var horizontal = new Vector2(rectangle.Top, rectangle.Bottom);
      //  var vertical = new Vector2(rectangle.Left, rectangle.Right);

      //  if (!rectangles.ContainsKey(horizontal))
      //    rectangles.Add(horizontal, new List<Rectangle>());
      //  rectangles[horizontal].Add(rectangle);

      //  if (!rectangles.ContainsKey(vertical))
      //    rectangles.Add(vertical, new List<Rectangle>());
      //  rectangles[vertical].Add(rectangle);
      //}

      //var ends = new List<Rectangle>();
      //foreach(var groupedRectangles in rectangles)
      //{
      //  var firstRectangle = groupedRectangles.Value.First();

      //  var x = firstRectangle.X;
      //  var y = firstRectangle.Y;
      //  var right = firstRectangle.Right;
      //  var bottom = firstRectangle.Bottom;
      //  foreach(var rectangle in groupedRectangles.Value)
      //  {
      //    if (rectangle.X < x)
      //      x = rectangle.X;

      //    if (rectangle.Y < y)
      //      y = rectangle.Y;

      //    if (rectangle.Right > right)
      //      right = rectangle.Right;

      //    if (rectangle.Bottom > bottom)
      //      bottom = rectangle.Bottom;
      //  }

      //  var finalRectangle = new Rectangle(x, y, right - x, bottom - y);
      //  ends.Add(finalRectangle);
      //}

      //_entities.Clear();

      //foreach(var end in ends)
      //{
      //  var entity = new Entity();
      //  entity.AddComponent(new CollisionComponent(entity, end, CollisionTypes.Static));
      //  _entities.Add(entity);
      //}
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
        entity.Update(gameTime);
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
