using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class JumpLeftState : BaseState
    {
        private bool _continueJump, _moveLeft;

        public JumpLeftState(AvatarEntity avatar, bool moving) : base(avatar)
        {
            _moveLeft = moving;
            _continueJump = Avatar.OnGround;
            Avatar.OnGround = false;
            LoadSprite();
        }

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateJumpLeftSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration,
                Avatar.OnGround);

        public override void JumpReleased() => _continueJump = false;

        public override void MoveRight() => TransitionJumpRight(true);

        public override void MoveLeft()
        {
            _moveLeft = true;
            Avatar.Acceleration = new Vector2(-1500, Avatar.Acceleration.Y);
        }

        public override void LeftReleased()
        {
            _moveLeft = false;
            Avatar.Acceleration = new Vector2(1500, Avatar.Acceleration.Y);
        }

        public override void Update(GameTime gameTime)
        {
            Avatar.Velocity = new Vector2(MathHelper.Clamp(Avatar.Velocity.X, -500, 0), Avatar.Velocity.Y);
            if (!Avatar.OnGround) return; //if still airborn, just continue
            if (_continueJump)
            {
                LoadSprite();
                Avatar.OnGround = false;
            }
            else if (_moveLeft)
            {
                TransitionMoveLeft();
            }
            else
            {
                TransitionFaceLeft();
            }
        }
    }
}