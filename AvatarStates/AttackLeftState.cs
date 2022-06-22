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
            MoveRightQueued = false;
            LoadSprite();
        }
        protected override void TransitionNextState()
        {
            if (!MoveRightQueued && !MoveLeftQueued)
                TransitionFaceLeft();
            else
                base.TransitionNextState();
        }

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateFacingLeftSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration);
    }
}
