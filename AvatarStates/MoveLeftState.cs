using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class MoveLeftState : BaseState
    {
        private bool _moveRightQueued;
        public MoveLeftState(AvatarEntity avatar) : base(avatar) => LoadSprite();

        private void LoadSprite() =>
            Avatar.Sprite = AvatarFactory.Instance.CreateMoveLeftSprite(Avatar.Position, Avatar.Velocity);

        public override void Jump() => TransitionJumpLeft(true, true);

        public override void LeftReleased()
        {
            if (_moveRightQueued)
                TransitionMoveRight();
            else
                TransitionFaceLeft();
        }

        public override void MoveRight() => _moveRightQueued = true;

        public override void RightReleased() => _moveRightQueued = false;

        public override void Update(GameTime gameTime) => Avatar.Velocity =
            new Vector2(MathHelper.Clamp(Avatar.Velocity.X, -500, 0), Avatar.Velocity.Y);
    }
}
