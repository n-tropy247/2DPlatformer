using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class AttackLeftState : AttackState
    {
        public AttackLeftState(AvatarEntity avatar, bool moving) : base(avatar)
        {
            Avatar.Acceleration = new Vector2(0, 0);
            Avatar.Velocity = new Vector2(0, 0);
            MoveLeftQueued = moving;
            LoadSprite();
        }

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateFacingLeftSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration);
    }
}
