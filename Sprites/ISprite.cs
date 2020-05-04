using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Sprites
{
    internal interface ISprite
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
