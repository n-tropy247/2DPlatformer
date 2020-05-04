using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Sprites
{
    class SpriteMovingNonAnimated : Sprite
    {
        public SpriteMovingNonAnimated(Texture2D sheet, Vector2 position, Vector2 velocity, Vector2 acceleration, int cols,
            int rows, int frame) : base(sheet, position, velocity, acceleration, rows, cols, frame, frame, false)
        {
        }
    }
}
