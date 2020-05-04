using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Collision;
using UnnamedGame.Entities;
using UnnamedGame.Sprites;

namespace UnnamedGame.World
{
    public class World : IDisposable
    {
        public const int Gravity = 2000;

        public AvatarEntity Avatar { get; }

        private Game1 game;
        private List<ISprite> sprites;
        private Viewport viewport;

        public World(Game1 gameInit)
        {
            game = gameInit;

            sprites = new List<ISprite>();
            Avatar = new AvatarEntity(new Vector2(10, 10));
            AddSprite(Avatar);

            viewport = game.GraphicsDevice.Viewport;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            sprites.ForEach(sprite => sprite.Draw(spriteBatch));

            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            CollisionDetector.ProcessCollisions(sprites, gameTime, game);
            sprites.ForEach(sprite => sprite.Update(gameTime));
        }

        public void AddSprite(ISprite sprite) => sprites.Add(sprite);
        public void RemoveSprite(ISprite sprite) => sprites.Remove(sprite);

        public void MoveLeft() => Avatar.MoveLeft();
        public void LeftReleased() => Avatar.LeftReleased();
        public void MoveRight() => Avatar.MoveRight();
        public void RightReleased() => Avatar.RightReleased();
        public void Jump() => Avatar.Jump();
        public void JumpReleased() => Avatar.JumpReleased();
        public void Dispose()
        {
        }
    }
}
