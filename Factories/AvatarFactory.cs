using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Sprites;

namespace UnnamedGame.Factories
{
    internal class AvatarFactory : Factory<AvatarFactory>
    {
        private const int AvatarWidth = 64, AvatarHeight = 128, SheetRows = 2, SheetCols = 4;
        private static readonly Vector2 BaseAcceleration = new Vector2(0, World.World.Gravity);

        public void LoadSheet(ContentManager mgr)
        {
            Atlas = mgr.Load<Texture2D>("avatar");
        }

        private static void AvatarBoundBox(ISprite sprite)
        {
            if (sprite != null)
                sprite.BoundBox = new Rectangle(new Point(0, 0), new Point(AvatarWidth - 1, AvatarHeight - 1));
        }

        public ISprite CreateFacingLeftSprite(Vector2 position, Vector2 velocity, Vector2 acceleration)
        {
            var adjustedAcceleration = acceleration + BaseAcceleration;
            ISprite sprite = new SpriteMovingNonAnimated(Atlas, position, velocity, adjustedAcceleration, SheetCols, SheetRows, 4);
            AvatarBoundBox(sprite);
            return sprite;
        }

        public ISprite CreateFacingRightSprite(Vector2 position, Vector2 velocity, Vector2 acceleration)
        {
            var adjustedAcceleration = acceleration + BaseAcceleration;
            ISprite sprite = new SpriteMovingNonAnimated(Atlas, position, velocity, adjustedAcceleration, SheetCols, SheetRows, 0);
            AvatarBoundBox(sprite);
            return sprite;
        }

        public ISprite CreateJumpLeftSprite(Vector2 position, Vector2 velocity, Vector2 acceleration, bool grounded)
        {
            var adjustedAcceleration = new Vector2(acceleration.X, BaseAcceleration.Y);
            var adjustedVelocity = velocity;
            if (grounded)
                adjustedVelocity = new Vector2(velocity.X, -500);
            ISprite sprite =
                new SpriteMovingNonAnimated(Atlas, position, adjustedVelocity, adjustedAcceleration, SheetCols, SheetRows, 5);
            AvatarBoundBox(sprite);
            return sprite;
        }

        public ISprite CreateJumpRightSprite(Vector2 position, Vector2 velocity, Vector2 acceleration, bool grounded)
        {
            var adjustedAcceleration = new Vector2(acceleration.X, BaseAcceleration.Y);
            var adjustedVelocity = velocity;
            if (grounded)
                adjustedVelocity = new Vector2(velocity.X, -500);
            ISprite sprite =
                new SpriteMovingNonAnimated(Atlas, position, adjustedVelocity, adjustedAcceleration, SheetCols, SheetRows, 1);
            AvatarBoundBox(sprite);
            return sprite;
        }

        public ISprite CreateMoveLeftSprite(Vector2 position, Vector2 velocity)
        {
            var adjustedAcceleration = new Vector2(-1000, 0) + BaseAcceleration;
            ISprite sprite = new SpriteMovingAnimated(Atlas, position, velocity, adjustedAcceleration, SheetCols, SheetRows, 5, 7);
            AvatarBoundBox(sprite);
            return sprite;
        }

        public ISprite CreateMoveRightSprite(Vector2 position, Vector2 velocity)
        {
            var adjustedAcceleration = new Vector2(1000, 0) + BaseAcceleration;
            ISprite sprite = new SpriteMovingAnimated(Atlas, position, velocity, adjustedAcceleration, SheetCols, SheetRows, 1, 3);
            AvatarBoundBox(sprite);
            return sprite;
        }
    }
}
