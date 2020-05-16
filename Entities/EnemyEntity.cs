using System;
using Microsoft.Xna.Framework;

namespace UnnamedGame.Entities
{
    public class EnemyEntity : BaseEntity
    {

        public EnemyEntity(Vector2 position) : base(position)
        {
            AvatarEntity.AttackOccurred += HandleAttack;
        }

        private static void HandleAttack()
        {
            Console.WriteLine("I've been attacked!");
        }
    }
}
