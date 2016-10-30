using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Pong__Open_Classroom_
{
    class SpriteBat : Sprite
    {
        private readonly int _playerNumber;
        private readonly int _screenHeight;
        private readonly int _screenWidth;

        public int Score { get; set; }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public SpriteBat(int screenWidth, int screenHeight, int playerNumber)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _playerNumber = playerNumber;
            Score = 0;
        }

        public override void LoadContent(ContentManager content, string assetName)
        {
            base.LoadContent(content, assetName);

            if (_playerNumber == 1)
            {
                Position = new Vector2(10, _screenHeight / 2 - Texture.Height / 2);
            }
            else if (_playerNumber == 2)
            {
                Position = new Vector2(_screenWidth - 10 - Texture.Width, _screenHeight / 2 - Texture.Height / 2);
            }
        }

        public override void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
            if (_playerNumber == 1)
            {
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    Direction = -Vector2.UnitY;
                    Speed = 0.7f;
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    Direction = Vector2.UnitY;
                    Speed = 0.7f;
                }
                else
                {
                    Speed = 0;
                }
            }
            else if (_playerNumber == 2)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    Direction = -Vector2.UnitY;
                    Speed = 0.7f;
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    Direction = Vector2.UnitY;
                    Speed = 0.7f;
                }
                else
                {
                    Speed = 0;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Position.Y <= 0 && Direction.Y < 0)
                Speed = 0;
            if (Position.Y >= _screenHeight - Texture.Height && Direction.Y > 0)
                Speed = 0;

            base.Update(gameTime);
        }
    }
}
