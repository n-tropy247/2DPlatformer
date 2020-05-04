using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UnnamedGame.Collision;
using UnnamedGame.Entities;
using UnnamedGame.Factories;
using UnnamedGame.Sprites;

namespace UnnamedGame.AvatarStates
{
    public abstract class BaseState
    {
        public AvatarEntity Avatar { get; }

        public BaseState(AvatarEntity avatar)
        {
            Avatar = avatar;
            LoadSprite();
        }

        protected virtual void LoadSprite()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void MoveLeft()
        {
        }

        public virtual void MoveRight()
        {
        }

        public virtual void Jump()
        {
        }

        public virtual void JumpReleased()
        {
        }

        public virtual void LeftReleased()
        {
        }

        public virtual void RightReleased()
        {
        }

        public virtual void HandleCollision(CollisionDetector.Collision collision, Game1 game)
        {
            if (collision.Direction == new Vector2(0, 1) && !Avatar.OnGround) //down
            {
                if (!Avatar.OnGround)
                {
                    Avatar.OnGround = true;
                    Avatar.Velocity = new Vector2(Avatar.Velocity.X, 0);
                }
            }

            if (Avatar.Velocity.Y > 0 && Avatar.OnGround) Avatar.OnGround = false;
        }

        protected void TransitionJumpLeft(bool moving) => Avatar.State = new JumpLeftState(Avatar, moving);
        
        protected void TransitionJumpRight(bool moving) => Avatar.State = new JumpRightState(Avatar, moving);

        protected void TransitionMoveLeft() => Avatar.State = new MoveLeftState(Avatar);

        protected void TransitionMoveRight() => Avatar.State = new MoveRightState(Avatar);

        protected void TransitionFaceLeft() => Avatar.State = new FaceLeftState(Avatar);

        public void TransitionFaceRight() => Avatar.State = new FaceRightState(Avatar);
    }
}
