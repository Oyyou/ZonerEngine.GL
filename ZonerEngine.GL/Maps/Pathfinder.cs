using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
    }

    private Map _map;

    public Pathfinder(Map map)
    {
      _map = map;
    }

    public List<Node> Nodes { get; private set; } = new List<Node>();

    public List<Point> GetPath(Point start, Point end)
    {
      var size = new Point(1, 1);
      if (!_map.FitsOnMap(start, size))
        return new List<Point>();

      if (!_map.FitsOnMap(end, size))
        return new List<Point>();

      if (_map.Collides(start, size))
        return new List<Point>();

      if (_map.Collides(end, size))
        return new List<Point>();

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
      path.Add(end);

      return path;
    }

    public List<Point> GetPathNextTo(Point start, Point end, bool includeCorners = false)
    {
      var neighbours = GetNeighbours(end, includeCorners);
      var results = neighbours.Select(c => GetPath(start, c));

      if (results.Count() == 0)
        return new List<Point>();

      return results.OrderBy(c => c.Count()).FirstOrDefault();
    }

    private List<Point> GetNeighbours(Point point, bool includeCorners = false)
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

      if (includeCorners)
      {
        if (x - 1 >= 0 && y - 1 >= 0) // Top-left
          result.Add(new Point(x - 1, y - 1));

        if (x + 1 < _map.Width && y - 1 >= 0) // Top-right
          result.Add(new Point(x + 1, y - 1));

        if (x + 1 < _map.Width && y + 1 < _map.Height) // Vottom-right
          result.Add(new Point(x + 1, y + 1));

        if (x - 1 >= 0 && y + 1 < _map.Height) // Bottom-left
          result.Add(new Point(x - 1, y + 1));
      }

      for (int i = 0; i < result.Count; i++)
      {
        if (_map.IsPassable(result[i].X, result[i].Y))
          continue;

        result.RemoveAt(i);
        i--;
      }

      return result;
    }
  }
}
