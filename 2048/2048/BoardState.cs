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
    class BoardState : Sprite
    {
        Tile[,] Board = new Tile[4, 4];

        KeyboardState keyboardState = Keyboard.GetState();

        public BoardState(Vector2 Position, Texture2D Texture, Vector2 size, Color Color) : base(Position, Texture, size, Color)
        {

            //for (int i = 0; i < Board.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Board.GetLength(1); j++)
            //    {
            //        Board[i, j] = new Tile();
            //    }
            //}
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            //Board[0, 0] = Board[1, 0];
            //Board[1, 0] = null;
            //Board[0, 0].Coordinates = new Point(0, 0);

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {

                }
            }

            for (int i = 0; i < Board.Length; i++)
            {
                //x * width + offsetx
                //y * height + offsety
                for (int j = 0; j < Board.Length; j++)
                {
                    //Board[i, j] = Board[i + 1, j];
                    //Board[i, j] = null;
                    //Board[i, j].Coordinates = new Point(i, j);

                    //foreach(Tile t in Board)
                    //{
                    //    //move t somehow?? idk
                    //}
                }


            }
        }

    }
}
