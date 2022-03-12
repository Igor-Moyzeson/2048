using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Sprite
    {
        public Vector2 Position;

        public Texture2D Texture;

        public Vector2 Size;

        public Color Color;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            }
        }

        public Sprite(Vector2 Position, Texture2D Texture, Vector2 size, Color Color)
        {
            this.Position = Position;
            this.Texture = Texture;
            this.Size = size;
            this.Color = Color;
        }

        public virtual void Draw (SpriteBatch sb)
        {
             sb.Draw(Texture, Hitbox, null, Color, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

    }
}
