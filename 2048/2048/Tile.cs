using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Tile : Sprite
    {


        public Point Coordinates;

        public int cellvalue;

        public Vector2 TargetPosition { get; set; }

        SpriteFont font;

        public Vector2 StartingPosition { get; set; }

        public double HowFarAlongTheLerpYouAre { get; set; } = 1;

        double step = .11;

        public Tile(Vector2 position, Texture2D texture, Vector2 size, Color color, int cellvalue, SpriteFont font)
            : base(position, texture, size, color)
        {
            this.cellvalue = cellvalue;
            this.font = font;
        }

        public void Update(GameTime gameTime)
        {
            HowFarAlongTheLerpYouAre += step;
            if (HowFarAlongTheLerpYouAre <= 1)
            {
                Position = Vector2.Lerp(StartingPosition, TargetPosition, (float)HowFarAlongTheLerpYouAre);
            }
            else
            {
                Position = TargetPosition;
            }
                

                return;

        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            var textSize = font.MeasureString(cellvalue.ToString()) / 2;
            sb.DrawString(font, cellvalue.ToString(), Position + new Vector2(Hitbox.Width/2, Hitbox.Height/2) - textSize, Color.Black);

        }

    }
}
