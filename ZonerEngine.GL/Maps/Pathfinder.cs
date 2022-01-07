﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ZonerEngine.GL.Maps
{
  public class Pathfinder
  {
    public class Node
    {
      public Point Point { get; set; }

      public int X => Point.X;

      public int Y => Point.Y;

      public List<Node> Paths = new List<Node>();
    }

    private Map _map;

    public Pathfinder(Map map)
    {
      _map = map;
    }

    public List<Node> Nodes { get; private set; } = new List<Node>();

    public List<Point> GetPath(Point start, Point end)
    {
      var frontier = new Queue<Point>();
      var reached = new HashSet<Point>();
      var cameFrom = new Dictionary<Point, Point>();

      frontier.Enqueue(start);
      reached.Add(start);
      cameFrom[start] = start;

      while (frontier.Count > 0)
      {
        var current = frontier.Dequeue();

        if (current == end)
          break;

        foreach (var next in GetNeighbours(current))
        {
          if (!reached.Contains(next))
          {
            frontier.Enqueue(next);
            reached.Add(next);

            cameFrom[next] = current;
          }
        }
      }

      var newCurrent = end;
      var path = new List<Point>();
      while (newCurrent != start)
      {
        if (newCurrent != end)
          path.Add(newCurrent);

        newCurrent = cameFrom[newCurrent];
      }

      path.Reverse();

      return path;
    }

    private List<Point> GetNeighbours(Point point)
    {
      var x = point.X;
      var y = point.Y;

      var result = new List<Point>();

      if (x - 1 >= 0)
        result.Add(new Point(x - 1, y));

      if (y - 1 >= 0)
        result.Add(new Point(x, y - 1));

      if (x + 1 < _map.Width)
        result.Add(new Point(x + 1, y));

      if (y + 1 < _map.Height)
        result.Add(new Point(x, y + 1));

      return result;
    }
  }
}