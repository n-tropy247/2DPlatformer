using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    class JumpRightState : BaseState
    {
        private bool _continueJump, _moveRight;
        public JumpRightState(AvatarEntity avatar, bool moving) : base(avatar)
        {
            _moveRight = moving;
            _continueJump = Avatar.OnGround;
            Avatar.OnGround = false;
        }

        protected override void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateJumpRightSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration, Avatar.OnGround);

        public override void JumpReleased() => _continueJump = false;

        public override void MoveLeft() => TransitionJumpLeft(true);

        public override void MoveRight()
        {
            _moveRight = true;
            Avatar.Acceleration = new Vector2(1500, Avatar.Acceleration.Y);
        }

        public override void RightReleased()
        {
            _moveRight = false;
            Avatar.Acceleration = new Vector2(-1500, Avatar.Acceleration.Y);
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
