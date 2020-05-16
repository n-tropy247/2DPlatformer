using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Collision;
using UnnamedGame.Entities;
using UnnamedGame.Sprites;

namespace UnnamedGame.World
{
    public class World
    {
        public static bool DrawBoundBox { get; private set; }

        public const int Gravity = 1000;

        private AvatarEntity Avatar { get; }

        private readonly Game1 _game;
        private readonly List<ISprite> _sprites;

        public World(Game1 gameInit)
        {
            _game = gameInit;

            _sprites = new List<ISprite>();
            Avatar = new AvatarEntity(new Vector2(10, 10));
            AddSprite(Avatar);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            _sprites.ForEach(sprite => sprite.Draw(spriteBatch));

            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            CollisionDetector.ProcessCollisions(_sprites, gameTime, _game);
            _sprites.ForEach(sprite => sprite.Update(gameTime));
        }

        public static void ToggleDrawBoundBox() => DrawBoundBox = !DrawBoundBox;

        public void AddSprite(ISprite sprite) => _sprites.Add(sprite);
        public void RemoveSprite(ISprite sprite) => _sprites.Remove(sprite);

        public void MoveLeft() => Avatar.MoveLeft();
        public void LeftReleased() => Avatar.LeftReleased();
        public void MoveRight() => Avatar.MoveRight();
        public void RightReleased() => Avatar.RightReleased();
        public void Jump() => Avatar.Jump();
        public void Attack() => Avatar.Attack();
        public void JumpReleased() => Avatar.JumpReleased();
    }
}
