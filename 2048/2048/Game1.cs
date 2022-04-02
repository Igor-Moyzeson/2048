using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2048
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public enum Directions
    {
        up,
        down,
        right,
        left,
        none
    }

    public enum ColorsEnum
    {
        red,
        slightly_less_red,
        less_red,
        almost_yellow,
        yellow,
        slightly_less_yellow,
        less_yellow,
        almost_blue,
        blue,
        slightly_less_blue,
        less_blue,
        black
    }


    public class Game1 : Game
    {


        SpriteFont font;

        public void MoveTile(Directions direction)
        {
            //Get movement working since gheneration is complete. 

            Vector2 start;
            if (amount < 1)
            {

                //Vector2 NewPosition = Vector2.Lerp(start, start + new Vector2(sizeOfCell.X + gapWidth, 0), amount);
                amount += 0.039f;
                //tiles.Position = NewPosition;

                if (amount >= 1)
                {
                    //tile.Position = start + new Vector2(sizeOfCell.X + gapWidth, 0);
                    amount = 0;
                    if (direction == Directions.up)
                    {

                    }
                }
            }
        }

        public void MovementLogic(Directions direction)
        {
            int targetCell = 0;
            int currentCell = 0;

            if(direction == Directions.none)
            {
                throw new Exception("HAHA UR DUMB");
            }

            if (direction == Directions.right)
            {
                targetCell = TilesPositions.GetLength(0) - 1;
                currentCell = TilesPositions.GetLength(0) - 2;
            }
            if (direction == Directions.left)
            {
                targetCell = 0;
                currentCell = 1;
            }
            if (direction == Directions.up)
            {
                targetCell = 0;
                currentCell = 1;
            }
            if (direction == Directions.down)
            {
                targetCell = TilesPositions.GetLength(1) - 1;
                currentCell = TilesPositions.GetLength(1) - 2;
            }

            if (direction == Directions.right)
            {
                for (int i = 0; i < TilesPositions.GetLength(0); i++)
                {
                    targetCell = TilesPositions.GetLength(0) - 1;
                    currentCell = TilesPositions.GetLength(0) - 2;

                    for (int j = 0; j < TilesPositions.GetLength(1) * 2; j++)
                    {

                        if (currentCell >= 0 && targetCell > 0)
                        {
                            if (TilesPositions[targetCell, i] != null && TilesPositions[currentCell, i] != null)
                            {
                                if (TilesPositions[targetCell, i].cellvalue == TilesPositions[currentCell, i].cellvalue)
                                {
                                    if (currentCell == targetCell)
                                    {
                                        currentCell--;
                                    }
                                    else
                                    {
                                        TilesPositions[targetCell, i].cellvalue = TilesPositions[targetCell, i].cellvalue * 2;
                                        TilesPositions[currentCell, i] = null;
                                        currentCell--;
                                        targetCell--;
                                    }
                                }
                                else
                                {
                                    targetCell--;
                                }

                            }
                            else
                            {
                                if (TilesPositions[targetCell, i] == null && TilesPositions[currentCell, i] != null)
                                {
                                    
                                    TilesPositions[targetCell, i] = TilesPositions[currentCell, i];
                                    TilesPositions[currentCell, i].TargetPosition = ScreenPositions[targetCell, i];
                                    TilesPositions[currentCell, i].StartingPosition = ScreenPositions[currentCell, i];

                                    TilesPositions[currentCell, i].HowFarAlongTheLerpYouAre = 0;

                                    TilesPositions[currentCell, i] = null;

                                }
                                currentCell--;
                            }

                        }
                    }
                }
                GenerateTiles();
            }

            if (direction == Directions.left)
            {

                for (int i = 0; i < TilesPositions.GetLength(0); i++)
                {
                    targetCell = 0;
                    currentCell = 1;
                    for (int j = 0; j < TilesPositions.GetLength(1) * 2; j++)
                    {
                        if (currentCell < 4 && targetCell < 3)
                        {
                            if (TilesPositions[targetCell, i] != null && TilesPositions[currentCell, i] != null)
                            {
                                if (TilesPositions[targetCell, i].cellvalue == TilesPositions[currentCell, i].cellvalue)
                                {
                                    if (currentCell == targetCell)
                                    {
                                        currentCell++;
                                    }
                                    else
                                    {
                                        TilesPositions[targetCell, i].cellvalue = TilesPositions[targetCell, i].cellvalue * 2;
                                        TilesPositions[currentCell, i] = null;
                                        currentCell++;
                                        targetCell++;
                                    }
                                }
                                else
                                {
                                    targetCell++;
                                }

                            }
                            else
                            {
                                if (TilesPositions[targetCell, i] == null && TilesPositions[currentCell, i] != null)
                                {
                                    TilesPositions[targetCell, i] = TilesPositions[currentCell, i];
                                    TilesPositions[currentCell, i].TargetPosition = ScreenPositions[targetCell, i];
                                    TilesPositions[currentCell, i].StartingPosition = ScreenPositions[currentCell, i];

                                    TilesPositions[currentCell, i].HowFarAlongTheLerpYouAre = 0;

                                    TilesPositions[currentCell, i] = null;

                                }
                                currentCell++;
                            }
                        }
                    }
                }
                GenerateTiles();
            }

            if (direction == Directions.up)
            {
                for (int i = 0; i < TilesPositions.GetLength(0); i++)
                {
                    targetCell = 0;
                    currentCell = 1;

                    for (int j = 0; j < TilesPositions.GetLength(1) * 2; j++)
                    {
                        if (currentCell < 4 && targetCell < 3)
                        {
                            if (TilesPositions[i, targetCell] != null && TilesPositions[i, currentCell] != null)
                            {
                                if (TilesPositions[i, targetCell].cellvalue == TilesPositions[i, currentCell].cellvalue)
                                {
                                    if (currentCell == targetCell)
                                    {
                                        currentCell++;
                                    }
                                    else
                                    {
                                        TilesPositions[i, targetCell].cellvalue = TilesPositions[i, targetCell].cellvalue * 2;
                                        TilesPositions[i, currentCell] = null;
                                        currentCell++;
                                        targetCell++;
                                    }
                                }
                                else
                                {
                                    targetCell++;
                                }

                            }
                            else
                            {
                                if (TilesPositions[i, targetCell] == null && TilesPositions[i, currentCell] != null)
                                {
                                    TilesPositions[i, targetCell] = TilesPositions[i, currentCell];
                                    TilesPositions[i, currentCell].TargetPosition = ScreenPositions[i, targetCell];
                                    TilesPositions[i, currentCell].StartingPosition = ScreenPositions[i, currentCell];

                                    TilesPositions[i, currentCell].HowFarAlongTheLerpYouAre = 0;

                                    TilesPositions[i, currentCell] = null;

                                }
                                currentCell++;
                            }
                        }
                    }
                }
                GenerateTiles();
            }

            if (direction == Directions.down)
            {
                for (int i = 0; i < TilesPositions.GetLength(0); i++)
                {
                    targetCell = TilesPositions.GetLength(1) - 1;
                    currentCell = TilesPositions.GetLength(1) - 2;

                    for (int j = 0; j < TilesPositions.GetLength(1) * 2; j++)
                    {
                        if (currentCell >= 0 && targetCell > 0)
                        {
                            if (TilesPositions[i, targetCell] != null && TilesPositions[i, currentCell] != null)
                            {
                                if (TilesPositions[i, targetCell].cellvalue == TilesPositions[i, currentCell].cellvalue)
                                {
                                    if (currentCell == targetCell)
                                    {
                                        currentCell--;
                                    }
                                    else
                                    {
                                        TilesPositions[i, targetCell].cellvalue = TilesPositions[i, targetCell].cellvalue * 2;
                                        TilesPositions[i, currentCell] = null;
                                        currentCell--;
                                        targetCell--;
                                    }
                                }
                                else
                                {
                                    targetCell--;
                                }

                            }
                            else
                            {
                                if (TilesPositions[i, targetCell] == null && TilesPositions[i, currentCell] != null)
                                {
                                    TilesPositions[i, targetCell] = TilesPositions[i, currentCell];
                                    TilesPositions[i, currentCell].TargetPosition = ScreenPositions[i, targetCell];
                                    TilesPositions[i, currentCell].StartingPosition = ScreenPositions[i, currentCell];

                                    TilesPositions[i, currentCell].HowFarAlongTheLerpYouAre = 0;

                                    TilesPositions[i, currentCell] = null;
                                }
                                currentCell--;
                            }

                        }
                    }
                }
                GenerateTiles();
            }

        }

        void GenerateTiles()
        {
            int xCord = rnd.Next(0, 4);
            int yCord = rnd.Next(0, 4);

            if (TilesPositions[xCord, yCord] == null)
            {
                TilesPositions[xCord, yCord] = new Tile(new Vector2(-10000, -10000), squaretexture, new Vector2(sizeOfCell.X, sizeOfCell.Y), Color.Red, 2, font);
            }
            else
            {
                while (TilesPositions[xCord, yCord] != null)
                {
                    xCord = rnd.Next(0, 4);
                    yCord = rnd.Next(0, 4);
                }
                TilesPositions[xCord, yCord] = new Tile(new Vector2(-10000,-10000), squaretexture, new Vector2(sizeOfCell.X, sizeOfCell.Y), Color.Red, 2, font);
            }
            //TilesPositions[2, 2] = new Tile(Vector2.Zero, squaretexture, new Vector2(sizeOfCell.X, sizeOfCell.Y), Color.Red, 2);
            //TilesPositions[3, 2] = new Tile(Vector2.Zero, squaretexture, new Vector2(sizeOfCell.X, sizeOfCell.Y), Color.Red, 2);
            
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BoardState board;

        Tile tile;

        Random rnd = new Random();

        Tile[,] TilesPositions = new Tile[4, 4];

        float amount = 0;

        Texture2D boardtexture;

        Texture2D squaretexture;

        KeyboardState keyboard;

        KeyboardState keyboardState = Keyboard.GetState();

        Vector2[,] ScreenPositions = new Vector2[4, 4];
        //This is where they are drawn

        Dictionary<int, Color> ColorMap = new Dictionary<int, Color>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


        }

        Vector2 sizeOfCell = new Vector2(39, 39);
        float gapWidth = 8;

        bool wantToGoRight = false;
        bool wantToGoLeft = false;
        bool wantToGoDown = false;
        bool wantToGoUp = false;

        //turn this into enums so that you only have one direction variable to clean up your code

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        void GenerateGrid(float gap, float cellsz)
        {


            for (int i = 0; i < ScreenPositions.GetLength(0); i++)
            {
                for (int j = 0; j < ScreenPositions.GetLength(1); j++)
                {
                    ScreenPositions[i, j] = new Vector2(board.Position.X + (i + 1) * gap + i * cellsz, board.Position.Y + (j + 1) * gap + j * cellsz);
                }
            }

        }

        //FIX CODE CUZ MERGE ISN"T WORKING CELL VALUE ISN"T UPDATING

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            boardtexture = Content.Load<Texture2D>("2048gameboard");

            squaretexture = Content.Load<Texture2D>("square");

            int GoalWidth = 300;
            int GoalHeight = 300;
            Vector2 scale = new Vector2(GoalWidth / (float)boardtexture.Width, GoalHeight / (float)boardtexture.Height);
            board = new BoardState(new Vector2(100, 100), boardtexture, new Vector2(GoalWidth, GoalHeight), Color.White);

            sizeOfCell *= scale;
            gapWidth *= scale.X;

            //for (int i = 0; i < 3; i++)
            //{
            //    Tiles.Add(new Tile(new Vector2((board.Position.X + (int)gapWidth) + (((i + 1) * (sizeOfCell.X + (int)gapWidth))), board.Position.Y + gapWidth), squaretexture, new Vector2(sizeOfCell.X, sizeOfCell.Y), Color.Red));
            //}

            //SET THE COLORS ENUMS

            //SET COLOR ENUMS AT HOME

            

            font = Content.Load<SpriteFont>("Font");


            Dictionary<Keys, Directions> keysToDirectionMap = new Dictionary<Keys, Directions>();

            keysToDirectionMap.Add(Keys.Up, Directions.up);
            keysToDirectionMap.Add(Keys.Down, Directions.down);
            keysToDirectionMap.Add(Keys.Right, Directions.right);
            keysToDirectionMap.Add(Keys.Left, Directions.left);

            ColorMap.Add(2, Color.DarkRed);
            ColorMap.Add(4, Color.Red);
            ColorMap.Add(8, new Color(110, 65, 65));
            

            GenerateGrid(gapWidth, sizeOfCell.X);


            GenerateTiles();
            GenerateTiles();
            GenerateTiles();
            GenerateTiles();
            GenerateTiles();
            GenerateTiles();
            GenerateTiles();
            //figure out why texture is messed up

            //tile = new Tile(new Vector2(113, 113), squaretexture, new Vector2(60, 60), Color.Red);



            IsMouseVisible = true;

            //oh ye also can i work on this stuff at home using github

            


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        Vector2 start;
        KeyboardState prevState;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //squares are 39 by 39
            //borders are 8 wide

            keyboardState = Keyboard.GetState();


            for (int i = 0; i < TilesPositions.GetLength(0); i++)
            {
                for (int j = 0; j < TilesPositions.GetLength(1); j++)
                {
                    if (TilesPositions[i, j] != null)
                    {
                        TilesPositions[i, j].Update(gameTime);
                        if (TilesPositions[i, j].HowFarAlongTheLerpYouAre >= 1)
                        {
                            TilesPositions[i, j].Position = ScreenPositions[i, j];
                        }
                    }
                }
            }

            Directions direction;
            if (keyboardState.IsKeyDown(Keys.Right) && !prevState.IsKeyDown(Keys.Right))
            {
                MovementLogic(Directions.right);
            }
            if (keyboardState.IsKeyDown(Keys.Left) && !prevState.IsKeyDown(Keys.Left))
            {
                MovementLogic(Directions.left);
            }
            if(keyboardState.IsKeyDown(Keys.Down) && !prevState.IsKeyDown(Keys.Down))
            {
                MovementLogic(Directions.down);
            }
            if(keyboardState.IsKeyDown(Keys.Up) && !prevState.IsKeyDown(Keys.Up))
            {
                MovementLogic(Directions.up);
            }


            //for (int i = 0; i < Tiles.Count; i++)
            //{
            //    if (keyboardState.IsKeyDown(Keys.Right) && wantToGoRight == false && wantToGoLeft == false && wantToGoUp == false && wantToGoDown == false && tile.Position.X <= 300)
            //    {
            //        start = Tiles[i].Position;
            //        wantToGoRight = true;
            //    }
            //    if (keyboardState.IsKeyDown(Keys.Left) && wantToGoRight == false && wantToGoLeft == false && wantToGoUp == false && wantToGoDown == false && tile.Position.X >= 150)
            //    {
            //        start = Tiles[i].Position;
            //        wantToGoLeft = true;
            //    }
            //    if (keyboardState.IsKeyDown(Keys.Up) && wantToGoRight == false && wantToGoLeft == false && wantToGoUp == false && wantToGoDown == false && tile.Position.Y >= 150)
            //    {
            //        start = Tiles[i].Position;
            //        wantToGoUp = true;
            //    }
            //    if (keyboardState.IsKeyDown(Keys.Down) && wantToGoRight == false && wantToGoLeft == false && wantToGoUp == false && wantToGoDown == false && tile.Position.Y <= 300)
            //    {
            //        start = Tiles[i].Position;
            //        wantToGoDown = true;
            //    }
            //}




            if (amount < 1 && wantToGoRight)
            {
                Vector2 NewPosition = Vector2.Lerp(start, start + new Vector2(sizeOfCell.X + gapWidth, 0), amount);
                amount += 0.039f;
                tile.Position = NewPosition;

                if (amount >= 1)
                {
                    tile.Position = start + new Vector2(sizeOfCell.X + gapWidth, 0);
                    amount = 0;
                    wantToGoRight = false;
                }
            }

            if (amount < 1 && wantToGoLeft)
            {
                Vector2 NewPosition = Vector2.Lerp(start, start - new Vector2(sizeOfCell.X + gapWidth, 0), amount);
                amount += 0.039f;
                tile.Position = NewPosition;

                if (amount >= 1)
                {
                    tile.Position = start - new Vector2(sizeOfCell.X + gapWidth, 0);
                    amount = 0;
                    wantToGoLeft = false;
                }
            }

            if (amount < 1 && wantToGoUp)
            {
                Vector2 NewPosition = Vector2.Lerp(start, start - new Vector2(0, sizeOfCell.X + gapWidth), amount);
                amount += 0.039f;
                tile.Position = NewPosition;

                if (amount >= 1)
                {
                    tile.Position = start - new Vector2(0, sizeOfCell.X + gapWidth);
                    amount = 0;
                    wantToGoUp = false;
                }
            }

            if (amount < 1 && wantToGoDown)
            {
                Vector2 NewPosition = Vector2.Lerp(start, start + new Vector2(0, sizeOfCell.X + gapWidth), amount);
                amount += 0.039f;
                tile.Position = NewPosition;

                if (amount >= 1)
                {
                    tile.Position = start + new Vector2(0, sizeOfCell.X + gapWidth);
                    amount = 0;
                    wantToGoDown = false;
                }

            }



            //TilePositions[i, j];


            //need a 2d array to start on the logic of the game
            //also get the border to work
            //malke the boardstate immutable
            //probably scrap all the lerping loll


            //get a sprite class
            //represent the game with nice classes
            // -Board class, Tile class
            // -Board update?

            //mvc
            // -separate the game state (tile values) from the drawing and the input
            // -BoardState class? with the values in a 2d array
            // -then your drawing
            // -class.Draw(spriteBatch, currentBoard);
            // -represent updates as transforming a BoardState
            // -var newBoard = currentBoard.Move(Direction.Left)
            // -restrict movement
            // -lerp to blend movement

            //basically stan told me to just generate a box and pick a number between 1-100 and since chances are 90-10 if a number is below 10 spawn 4 but if above spawn 2

            //draw a box with 3 vertical and perpendicular lines

            //finish sql stuffs

            //each box is 107 pixels on the side and they are all squares

            //sql in the background for highscore and accounts

            //lerp in order to smoothly move the square from box to box

            prevState = keyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            board.Draw(spriteBatch);

            //tile.Draw(spriteBatch);

            //for (int i = 0; i < Tiles.Count; i++)
            //{
            //    Tiles[i].Draw(spriteBatch);
            //}

            for (int i = 0; i < TilesPositions.GetLength(0); i++)
            {
                for (int j = 0; j < TilesPositions.GetLength(1); j++)
                {
                    if (TilesPositions[i, j] != null)
                    {
                        TilesPositions[i, j].Draw(spriteBatch);
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
