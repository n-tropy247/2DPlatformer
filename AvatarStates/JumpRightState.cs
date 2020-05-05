using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class JumpRightState : BaseState
    {
        private bool _continueJump, _moveRight, _moveLeftQueued;

        public JumpRightState(AvatarEntity avatar, bool moving, bool continueJump) : base(avatar)
        {
            _moveRight = moving;
            _continueJump = continueJump;
            Avatar.OnGround = false;
            LoadSprite();
        }

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateJumpRightSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration,
                Avatar.OnGround);

        public override void JumpReleased() => _continueJump = false;

        public override void MoveLeft()
        {
            if (!_moveRight)
                TransitionJumpLeft(true, _continueJump);
            else
                _moveLeftQueued = true;
        } 

        public override void LeftReleased() => _moveLeftQueued = false;

        public override void MoveRight()
        {
            _moveRight = true;
            Avatar.Acceleration = new Vector2(1500, Avatar.Acceleration.Y);
        }

        public override void RightReleased()
        {
            Avatar.Acceleration = new Vector2(-1500, Avatar.Acceleration.Y);
            if (_moveLeftQueued)
                TransitionJumpLeft(true, _continueJump);
            else
                _moveRight = false;
        }

        public override void Update(GameTime gameTime)
        {
            Avatar.Velocity = new Vector2(MathHelper.Clamp(Avatar.Velocity.X, 0, 500), Avatar.Velocity.Y);
            if (Avatar.OnGround)
            {
                if (_continueJump)
                {
                    LoadSprite();
                    Avatar.OnGround = false;
                }
                else if (_moveRight)
                {
                    TransitionMoveRight();
                }
                else
                {
                    TransitionFaceRight();
                }
            }
        }
    }
}
