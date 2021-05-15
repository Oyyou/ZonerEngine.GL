using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZonerEngine.GL.UI.Texts
{
  public class Text
  {
    public SpriteFont Font { get; set; }

    public StringBuilder Value { get; set; }

    public Vector2 Position { get; set; }

    public Color Colour { get; set; }

    public float Opacity { get; set; }

    public int Width
    {
      get
      {
        return (int)Font.MeasureString(Value).X;
      }
    }

    public int Height
    {
      get
      {
        return (int)Font.MeasureString(Value).Y;
      }
    }

    public Text(SpriteFont font, StringBuilder value)
    {
      Font = font;
      Value = value;
      Position = new Vector2(0, 0);
      Colour = Color.Black;
      Opacity = 1f;
    }

    public virtual void Update(GameTime gameTime)
    {

    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.DrawString(Font, Value, Position, Colour * Opacity);
    }
  }
}
