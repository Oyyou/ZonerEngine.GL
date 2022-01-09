using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ZonerEngine.GL.Components;

namespace ZonerEngine.GL.Maps
{
  public class Map
  {
    public char[,] Data { get; private set; }

    public int Width => Data.GetLength(1);

    public int Height => Data.GetLength(0);

    public Map(char[,] data)
    {
      Data = data;
    }

    public Map(int width, int height, char defaultChar)
    {
      Data = new char[height, width];

      for (int y = 0; y < Height; y++)
      {
        for (int x = 0; x < Width; x++)
        {
          Data[y, x] = defaultChar;
        }
      }
    }

    public void Add(MappedComponent obj)
    {
      if (Collides(obj))
      {
        return;
      }

      for (int y = obj.Y; y < obj.Bottom; y++)
      {
        for (int x = obj.X; x < obj.Right; x++)
        {
          Data[y, x] = obj.MapChar;
        }
      }
    }

    public bool Collides(MappedComponent obj)
    {
      if (!FitsOnMap(obj))
        return true;

      for (int y = obj.Y; y < obj.Bottom; y++)
      {
        for (int x = obj.X; x < obj.Right; x++)
        {
          if (Data[y, x] != '0')
            return true;
        }
      }
      return false;
    }

    public bool FitsOnMap(MappedComponent obj)
    {
      if (obj.X < 0)
        return false;

      if (obj.Y < 0)
        return false;

      if (obj.Bottom > Height)
        return false;

      if (obj.Right > Width)
        return false;

      return true;
    }

    public void WriteMap()
    {
      Console.Clear();

      for (int y = 0; y < Height; y++)
      {
        for (int x = 0; x < Width; x++)
        {
          Console.Write(Data[y, x]);
        }
        Console.WriteLine();
      }
    }

    public bool IsPassable(int x, int y)
    {
      return Data[y, x] == '0';
    }

    public bool IsPassable(Point point)
    {
      return IsPassable(point.X, point.Y);
    }
  }
}
