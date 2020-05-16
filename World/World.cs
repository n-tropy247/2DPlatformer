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

        private readonly AvatarEntity _avatar;

        private readonly Game1 _game;
        private readonly List<ISprite> _sprites;

        public World(Game1 gameInit)
        {
            _game = gameInit;

            _sprites = new List<ISprite>();
            _avatar = new AvatarEntity(new Vector2(10, 10));
            var enemyTest = new EnemyEntity(new Vector2(0, 0));
            AddSprite(_avatar);
            AddSprite(enemyTest);
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

        public void MoveLeft() => _avatar.MoveLeft();
        public void LeftReleased() => _avatar.LeftReleased();
        public void MoveRight() => _avatar.MoveRight();
        public void RightReleased() => _avatar.RightReleased();
        public void Jump() => _avatar.Jump();
        public void Attack() => _avatar.Attack();
        public void JumpReleased() => _avatar.JumpReleased();
    }
}
