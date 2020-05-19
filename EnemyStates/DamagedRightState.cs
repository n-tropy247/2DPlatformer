using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.EnemyStates
{
    internal class DamagedRightState : BaseState
    {
        public DamagedRightState(EnemyEntity enemy) : base(enemy)
        {
            Enemy.OnGround = false;
            Enemy.Velocity = new Vector2(-500, -500);
            LoadSprite();
        }

        private void LoadSprite() => Enemy.Sprite =
            EnemyFactory.Instance.CreateDamagedEnemySprite(Enemy.Position, Enemy.Velocity, Enemy.Acceleration);

        public override void Update(GameTime gameTime)
        {
            if (Enemy.OnGround)
                TransitionFaceRightState();
        }
    }
}
