using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Sprites
{
    internal class SpriteNonMovingAnimated : Sprite
    {
        public SpriteNonMovingAnimated(Texture2D sheet, Vector2 position, int cols, int rows, int start, int end) :
            base(sheet, position, Vector2.Zero, Vector2.Zero, rows, cols, start, end, true)
        {
        }
    }
}
