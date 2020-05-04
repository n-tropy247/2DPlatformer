using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Sprites
{
    internal class SpriteNonMovingNonAnimated : Sprite
    {
        public SpriteNonMovingNonAnimated(Texture2D sheet, Vector2 position, int cols, int rows, int frame) :
            base(sheet, position, Vector2.Zero, Vector2.Zero, rows, cols, frame, frame, false)
        {
        }
    }
}
