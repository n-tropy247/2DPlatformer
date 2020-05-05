using Microsoft.Xna.Framework;
using UnnamedGame.Entities;

namespace UnnamedGame.AvatarStates
{
    public abstract class BaseState
    {
        protected AvatarEntity Avatar { get; }

        protected BaseState(AvatarEntity avatar) => Avatar = avatar;

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

        public void HandleCollision(Collision.Collision collision)
        {
            if (collision.Direction == new Vector2(0, 1) && !Avatar.OnGround) //down
            {
                if (!Avatar.OnGround)
                {
                    Avatar.OnGround = true;
                    Avatar.Velocity = new Vector2(Avatar.Velocity.X, 0);
                }
            }
            else if (collision.Direction == new Vector2(1, 0)) //right
            {
                if (Avatar.Velocity.X >= 0)
                    Avatar.Velocity = new Vector2(0, Avatar.Velocity.Y);
                else
                    Avatar.Position += new Vector2(0, 1);
            }
            else if (collision.Direction == new Vector2(-1, 0)) //left
            {
                if (Avatar.Velocity.X <= 0)
                    Avatar.Velocity = new Vector2(0, Avatar.Velocity.Y);
                else
                    Avatar.Position += new Vector2(0, 1);
            }
            else if (collision.Direction == new Vector2(0, -1))
            {
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
