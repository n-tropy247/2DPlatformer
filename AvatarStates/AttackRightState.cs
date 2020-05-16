using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class AttackRightState : AttackState
    {
        public AttackRightState(AvatarEntity avatar, bool moving) : base(avatar)
        {
            Avatar.Acceleration = new Vector2(0, 0);
            Avatar.Velocity = new Vector2(0, 0);
            MoveRightQueued = moving;
            LoadSprite();
        }

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateFacingRightSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration);
    }
}
