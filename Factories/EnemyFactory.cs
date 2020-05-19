using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Sprites;

namespace UnnamedGame.Factories
{
    internal class EnemyFactory : Factory<EnemyFactory>
    {
        private const int EnemyWidth = 64, EnemyHeight = 128, SheetRows = 1, SheetCols = 2;
        private static readonly Vector2 BaseAcceleration = new Vector2(0, World.World.Gravity);

        public void LoadSheet(ContentManager mgr)
        {
            Atlas = mgr.Load<Texture2D>("enemy");
        }

        private static void EnemyBoundBox(ISprite sprite)
        {
            if (sprite != null)
                sprite.BoundBox = new Rectangle(new Point(0, 0), new Point(EnemyWidth - 1, EnemyHeight - 1));
        }

        public ISprite CreateStandardEnemySprite(Vector2 position, Vector2 velocity, Vector2 acceleration)
        {
            var adjustedAcceleration = new Vector2(acceleration.X, BaseAcceleration.Y);
            ISprite sprite = new SpriteMovingNonAnimated(Atlas, position, velocity, adjustedAcceleration, SheetCols, SheetRows, 0);
            EnemyBoundBox(sprite);
            return sprite;
        }

        public ISprite CreateDamagedEnemySprite(Vector2 position, Vector2 velocity, Vector2 acceleration)
        {
            var adjustedAcceleration = new Vector2(acceleration.X, BaseAcceleration.Y);
            ISprite sprite = new SpriteMovingNonAnimated(Atlas, position, velocity, adjustedAcceleration, SheetCols, SheetRows, 1);
            EnemyBoundBox(sprite);
            return sprite;
        }
    }
}
