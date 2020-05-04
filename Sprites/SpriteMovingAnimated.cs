using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Sprites
{
    class SpriteMovingAnimated : Sprite
    {
        public SpriteMovingAnimated(Texture2D sheet, Vector2 position, Vector2 velocity, Vector2 acceleration, int cols,
            int rows, int start, int end) : base(sheet, position, velocity, acceleration, rows, cols, start, end, true)
        {
        }
    }
}
