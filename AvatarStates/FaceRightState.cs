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
    class FaceRightState : BaseState
    {
        public FaceRightState(AvatarEntity avatar) : base(avatar) => Avatar.Acceleration = new Vector2(-1500, Avatar.Acceleration.Y);

        protected override void LoadSprite() => Avatar.Sprite =
            AvatarFactory.Instance.CreateFacingRightSprite(Avatar.Position, Avatar.Velocity, Avatar.Acceleration);

        public override void Jump() => TransitionJumpRight(false);

        public override void MoveLeft() => TransitionMoveLeft();

        public override void MoveRight() => TransitionMoveRight();

        public override void Update(GameTime gameTime) => Avatar.Velocity =
            new Vector2(MathHelper.Clamp(Avatar.Velocity.X, 0, 500), Avatar.Velocity.Y);
    }
}
