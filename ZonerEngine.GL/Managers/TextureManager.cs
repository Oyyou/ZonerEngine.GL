using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZonerEngine.GL.Managers
{
  public class TextureManager
  {
    private GraphicsDevice _graphicsDevice;

    public TextureManager(GraphicsDevice graphicsDevice)
    {
      _graphicsDevice = graphicsDevice;
    }

    public Texture2D GetRectangleBorder(Rectangle rectangle, Color colour)
    {
      var texture = new Texture2D(_graphicsDevice, rectangle.Width, rectangle.Height);
      var colours = new Color[texture.Width * texture.Height];
      int index = 0;

      for (int y = 0; y < texture.Height; y++)
      {
        for (int x = 0; x < texture.Width; x++)
        {
          if (x <= 0 || x >= (texture.Width - 1) ||
             y <= 0 || y >= (texture.Height - 1))
          {
            colours[index] = colour;
          }
          index++;
        }
      }

      texture.SetData(colours);

      return texture;
    }

    public Texture2D GetBlock(int width, int height, Color colour)
    {
      var texture = new Texture2D(_graphicsDevice, width, height);
      var colours = new Color[texture.Width * texture.Height];

      int index = 0;

      for (int y = 0; y < texture.Height; y++)
      {
        for (int x = 0; x < texture.Width; x++)
        {
          colours[index] = colour;

          index++;
        }
      }

      texture.SetData(colours);

      return texture;
    }
  }
}
