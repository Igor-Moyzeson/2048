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

        public Tile(Vector2 position, Texture2D texture, Vector2 size, Color color, int cellvalue)
            : base(position, texture, size, color)
        {
            this.cellvalue = cellvalue;
        }

        public void Update(GameTime gameTime)
        {
            if (TargetPosition == Position)


                return;

        }

    }
}
