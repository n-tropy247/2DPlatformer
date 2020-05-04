using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Sprites;

namespace UnnamedGame.Entities
{
    public abstract class BaseEntity : ISprite
    {
        public ISprite Sprite { get; set; }
        private Vector2 _position;

        public Vector2 Position
        {
            get => Sprite?.Position ?? _position;
            set
            {
                if (Sprite == null)
                    _position = value;
                else
                    Sprite.Position = value;
            }
        }

        public Vector2 Velocity
        {
            get => Sprite?.Velocity ?? Vector2.Zero;
            set
            {
                if (Sprite != null) Sprite.Velocity = value;
            }
        }

        public Vector2 Acceleration
        {
            get => Sprite?.Acceleration ?? Vector2.Zero;
            set
            {
                if (Sprite != null) Sprite.Acceleration = value;
            }
        }

        public Rectangle BoundBox
        {
            get => Sprite?.BoundBox ?? new Rectangle();
            set
            {
                if (Sprite != null) Sprite.BoundBox = value;
            }
        }

        protected BaseEntity(Vector2 position)
        {
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite?.Draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite?.Update(gameTime);
        }

        public virtual void HandleCollision(Collision.Collision collision, Game1 game)
        {
        }
    }
}
