using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Collision;

namespace UnnamedGame.Sprites
{
    public interface ISprite
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        Rectangle BoundBox { get; set; }

        CollisionDetector.EntityType EntityType { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void HandleCollision(Collision.Collision collision, Game1 game);
    }
}
