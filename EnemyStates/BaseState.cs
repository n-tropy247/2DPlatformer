using Microsoft.Xna.Framework;
using UnnamedGame.Entities;

namespace UnnamedGame.EnemyStates
{
    public abstract class BaseState
    {
        protected EnemyEntity Enemy { get; }

        protected BaseState(EnemyEntity avatar) => Enemy = avatar;

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void TakeDamage()
        {
        }

        public void HandleCollision(Collision.Collision collision)
        {
            if (collision.Direction == new Vector2(0, 1) && !Enemy.OnGround) //down
            {
                if (!Enemy.OnGround)
                {
                    Enemy.OnGround = true;
                    Enemy.Velocity = new Vector2(Enemy.Velocity.X, 0);
                }
            }
            else if (collision.Direction == new Vector2(1, 0)) //right
            {
                if (Enemy.Velocity.X >= 0)
                    Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y);
                else
                    Enemy.Position += new Vector2(0, 1);
            }
            else if (collision.Direction == new Vector2(-1, 0)) //left
            {
                if (Enemy.Velocity.X <= 0)
                    Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y);
                else
                    Enemy.Position += new Vector2(0, 1);
            }
            else if (collision.Direction == new Vector2(0, -1))
            {
            }

            if (Enemy.Velocity.Y > 0 && Enemy.OnGround) Enemy.OnGround = false;
        }

        protected void TransitionDamageLeftState() => Enemy.State = new DamagedLeftState(Enemy);
        protected void TransitionDamageRightState() => Enemy.State = new DamagedRightState(Enemy);
        public void TransitionFaceLeftState() => Enemy.State = new FaceLeftState(Enemy);
        protected void TransitionFaceRightState() => Enemy.State = new FaceRightState(Enemy);
    }
}
