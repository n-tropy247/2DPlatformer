using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class FaceLeftState : BaseState
    {
        public FaceLeftState(AvatarEntity avatar) : base(avatar)
        {
            Avatar.Acceleration = new Vector2(1500, Avatar.Acceleration.Y);
            LoadSprite();
        }

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateFacingLeftSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration);

        public override void Jump() => TransitionJumpLeft(false, true);

        public override void MoveLeft() => TransitionMoveLeft();

        public override void MoveRight() => TransitionMoveRight();

        public override void Update(GameTime gameTime) => Avatar.Velocity =
            new Vector2(MathHelper.Clamp(Avatar.Velocity.X, -500, 0), Avatar.Velocity.Y);
    }
}
