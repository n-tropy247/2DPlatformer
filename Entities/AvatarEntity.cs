using Microsoft.Xna.Framework;
using UnnamedGame.AvatarStates;

namespace UnnamedGame.Entities
{
    public class AvatarEntity : BaseEntity
    {
        public BaseState State { get; set; }
        public bool OnGround { get; set; }

        public AvatarEntity(Vector2 position) : base(position)
        {
            OnGround = false;
            State = new FaceRightState(this);
            State.TransitionFaceRight();
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            base.Update(gameTime);
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }

        public void Jump()
        {
            if (OnGround)
                State.Jump();
        }

        public void JumpReleased()
        {
            State.JumpReleased();
        }

        public void LeftReleased()
        {
            State.LeftReleased();
        }

        public void RightReleased()
        {
            State.RightReleased();
        }

        public override void HandleCollision(Collision.Collision collision, Game1 game)
        {
            State.HandleCollision(collision);
        }
    }
}
