using Microsoft.Xna.Framework;
using UnnamedGame.Collision;
using UnnamedGame.EnemyStates;

namespace UnnamedGame.Entities
{
    public class EnemyEntity : BaseEntity
    {
        public BaseState State { get; set; }
        public bool OnGround { get; set; }
        public World.World World { get; }

        private const int AttackRange = 150; //number of pixels away avatar must be to cause damage

        public EnemyEntity(Vector2 position, World.World world) : base(position)
        {
            AvatarEntity.AttackOccurred += HandleAttack;
            World = world;
            EntityType = CollisionDetector.EntityType.Enemy;
            State = new FaceLeftState(this);
            State.TransitionFaceLeftState();
            OnGround = false;
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            base.Update(gameTime);
        }

        public override void HandleCollision(Collision.Collision collision, Game1 game)
        {
            State?.HandleCollision(collision);
            Sprite?.HandleCollision(collision, game);
        }

        private void HandleAttack(Vector2 avatarPos)
        {
            if (Vector2.Distance(avatarPos, Position) <= AttackRange)
                State.TakeDamage();
        }
    }
}
