using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class MoveRightState : BaseState
    {
        private bool _moveLeftQueued;
        public MoveRightState(AvatarEntity avatar) : base(avatar) => LoadSprite();

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateMoveRightSprite(Avatar.Position, Avatar.Velocity);

        public override void Jump() => TransitionJumpRight(true, true);

        public override void RightReleased()
        {
            if (_moveLeftQueued)
                TransitionMoveLeft();
            else
                TransitionFaceRight();
        }

        public override void MoveLeft() => _moveLeftQueued = true;

        public override void LeftReleased() => _moveLeftQueued = false;

        public override void Update(GameTime gameTime) => Avatar.Velocity =
            new Vector2(MathHelper.Clamp(Avatar.Velocity.X, 0, 500), Avatar.Velocity.Y);
    }
}
