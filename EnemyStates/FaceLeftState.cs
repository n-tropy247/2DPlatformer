using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.EnemyStates
{
    internal class FaceLeftState : BaseState
    {
        public FaceLeftState(EnemyEntity enemy) : base(enemy)
        {
            Enemy.Acceleration = new Vector2(-500, Enemy.Acceleration.Y);
            LoadSprite();
        }

        private void LoadSprite() => Enemy.Sprite =
            EnemyFactory.Instance.CreateStandardEnemySprite(Enemy.Position, Enemy.Velocity, Enemy.Acceleration);

        public override void TakeDamage() => TransitionDamageLeftState();

        public override void Update(GameTime gameTime)
        {
            Enemy.Velocity = new Vector2(MathHelper.Clamp(Enemy.Velocity.X, -250, 0), Enemy.Velocity.Y);
            if (Enemy.Position.X < Enemy.World.GetAvatarPosition().X)
            {
                TransitionFaceRightState();
            }
        }
    }
}
