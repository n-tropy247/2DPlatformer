using Microsoft.Xna.Framework;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    internal class MoveRightState : BaseState
    {
        public MoveRightState(AvatarEntity avatar) : base(avatar) => LoadSprite();

        private void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateMoveRightSprite(Avatar.Position, Avatar.Velocity);

        public override void Jump() => TransitionJumpRight(true);

        public override void RightReleased() => TransitionFaceRight();

        public override void Update(GameTime gameTime) => Avatar.Velocity =
            new Vector2(MathHelper.Clamp(Avatar.Velocity.X, 0, 500), Avatar.Velocity.Y);
    }
}
