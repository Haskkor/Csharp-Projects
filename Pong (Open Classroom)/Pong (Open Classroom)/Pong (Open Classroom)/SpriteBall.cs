using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Pong__Open_Classroom_
{
    class SpriteBall : Sprite
    {
        private int _screenHeight;
        private int _screenWidth;

        public SpriteBall(int screenWidth, int screenHeight)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
        }

        public override void Initialize()
        {
            int dirX;
            int dirY;
            CryptoRandom rand = new CryptoRandom();
            int randDir = rand.Next(1,4);
            switch (randDir)
            {
                case 1 :
                    dirX = -1;
                    dirY = -1;
                    break;
                case 2 :
                    dirX = -1;
                    dirY = 1;
                    break;                        
                case 3 :
                    dirX = 1;
                    dirY = -1;
                    break;                        
                case 4 :
                    dirX = 1;
                    dirY = 1;
                    break;    
                default :
                    dirX = 1;
                    dirY = 1;
                    break;
            }
            base.Initialize();
            Direction = new Vector2(dirX,dirY);
            Speed = 0.5f;
        }

        public override void LoadContent(ContentManager content, String assetName)
        {
            base.LoadContent(content, assetName);
            Position = new Vector2(_screenWidth / 2 - Texture.Width / 2, _screenHeight / 2 - Texture.Height);
        }

        public void Update(GameTime gameTime, Rectangle batRectPlay1, Rectangle batRectPlay2)
        {
            if ((Position.Y <= 0 && Direction.Y < 0) || (Position.Y > _screenHeight - Texture.Height && Direction.Y > 0))
            {
                Direction = new Vector2(Direction.X, -Direction.Y);
            }

            if ((Direction.X < 0 && batRectPlay1.Contains((int)Position.X, (int)Position.Y + Texture.Height / 2)) || (Direction.X > 0 && batRectPlay2.Contains((int)Position.X + Texture.Width, (int)Position.Y + Texture.Height / 2)))
            {
                Direction = new Vector2(-Direction.X, Direction.Y);
                Speed += 0.05f;
            }

            base.Update(gameTime);
        }
    }
}
