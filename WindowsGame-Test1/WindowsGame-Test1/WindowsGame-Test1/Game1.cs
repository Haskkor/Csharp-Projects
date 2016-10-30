using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame_Test1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Sprite1 _aragorn;
        //private Texture2D _aragorn;
        //private Vector2 _aragornPosition;
        //private Vector2 _aragornDirection;
        private int _screenWidth;
        private int _screenHeight;
        //private float _aragornSpeed = 1f;
        private SpriteFont _font;
        private KeyboardState _keyboardState;
        //private KeyboardState _oldKeyboardState;
        private MouseState _mouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //_aragornPosition = Vector2.Zero;
            //_aragornDirection = Vector2.Normalize(Vector2.One);

            _screenWidth = Window.ClientBounds.Width;
            _screenHeight = Window.ClientBounds.Height;

            _aragorn = new Sprite1();
            _aragorn.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //_aragorn = Content.Load<Texture2D>("chozo-mj-tux-aragorn-1886");

            _font = Content.Load<SpriteFont>("FontTest");

            _aragorn.LoadContent(Content, "chozo-mj-tux-aragorn-1886");

            //_aragornPosition = new Vector2(_screenWidth / 2 - _aragorn.Width / 2, _screenHeight / 2 - _aragorn.Height / 2);
        }

        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();

            _aragorn.Update(gameTime);

            /*if (_keyboardState.IsKeyDown(Keys.Up) && _oldKeyboardState.IsKeyUp(Keys.Up))
            {
                _aragornPosition.Y--;
            }
            if (_keyboardState.IsKeyDown(Keys.Down) && _oldKeyboardState.IsKeyUp(Keys.Down))
            {
                _aragornPosition.Y++;
            }
            if (_keyboardState.IsKeyDown(Keys.Right) && _oldKeyboardState.IsKeyUp(Keys.Right))
            {
                _aragornPosition.X++;
            }
            if (_keyboardState.IsKeyDown(Keys.Left) && _oldKeyboardState.IsKeyUp(Keys.Left))
            {
                _aragornPosition.X--;
            }*/

            //_aragornPosition.X = _mouseState.X;
            //_aragornPosition.Y = _mouseState.Y;

            //_oldKeyboardState = _keyboardState;

            /*_aragornPosition += _aragornDirection * _aragornSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if ((_aragornDirection.X < 0 && _aragornPosition.X <= 0) || (_aragornDirection.X > 0 && _aragornPosition.X + _aragorn.Width >= _screenWidth))
            {
                _aragornDirection.X = -_aragornDirection.X;
            }

            if ((_aragornDirection.Y < 0 && _aragornPosition.Y <= 0) || (_aragornDirection.Y > 0 && _aragornPosition.Y + _aragorn.Height >= _screenHeight))
            {
                _aragornDirection.Y = -_aragornDirection.Y;
            }*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //  !!!!!!!!!!!!!!!!!     measureString    !!!!!!!!!!!!!!
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "Lord of the Rings", new Vector2(10,20), Color.White);
            //spriteBatch.Draw(_aragorn, _aragornPosition, Color.White);
            _aragorn.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
