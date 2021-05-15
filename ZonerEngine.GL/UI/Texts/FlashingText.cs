using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZonerEngine.GL.UI.Texts
{
    public class FlashingText : Text
    {
        private bool _goingUp;

        public float MaxOpacity { get; set; }

        public float MinOpacity { get; set; }

        /// <summary>
        /// How quickly the opacity changes
        /// </summary>
        public float IncrementSpeed { get; set; }

        public FlashingText(SpriteFont font, StringBuilder value, float startOpacity) : base(font, value)
        {
            Opacity = startOpacity;
            MaxOpacity = 1;
            MinOpacity = 0;
            _goingUp = true;
            IncrementSpeed = 0.01f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_goingUp)
            {
                Opacity += IncrementSpeed;
                if (Opacity >= MaxOpacity)
                {
                    _goingUp = false;
                    Opacity = MaxOpacity;
                }
            }
            else
            {
                Opacity -= IncrementSpeed;
                if (Opacity <= MinOpacity)
                {
                    _goingUp = true;
                    Opacity = MinOpacity;
                }
            }
        }
    }
}
