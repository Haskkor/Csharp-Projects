using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong__Open_Classroom_
{
    class Sprite
    {
        /// Récupère ou définit l'image du sprite
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
        private Texture2D _texture;

        /// Récupère ou définit la position du Sprite
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private Vector2 _position;

        /// Récupère ou définit la direction du sprite. Lorsque la direction est modifiée, elle est automatiquement normalisée.
        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = Vector2.Normalize(value); }
        }
        private Vector2 _direction;

        /// Récupère ou définit la vitesse de déplacement du sprite.
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        private float _speed;

        /// Initialise les variables du Sprite
        public virtual void Initialize()
        {
            _position = Vector2.Zero;
            _direction = Vector2.Zero;
            _speed = 0;
        }

        /// Charge l'image voulue grâce au ContentManager donné
        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }

        /// Met à jour les variables du sprite
        public virtual void Update(GameTime gameTime)
        {
            _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// Permet de gérer les entrées du joueur
        public virtual void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
        }

        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
