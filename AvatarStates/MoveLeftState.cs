using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnamedGame.Entities;
using UnnamedGame.Factories;

namespace UnnamedGame.AvatarStates
{
    class MoveLeftState : BaseState
    {
        public MoveLeftState(AvatarEntity avatar) : base(avatar)
        {
        }

        protected override void LoadSprite() =>
            Avatar.Sprite = AvatarFactory.Instance.CreateMoveLeftSprite(Avatar.Position, Avatar.Velocity);

        public override void Jump() => TransitionJumpLeft(true);

        public override void LeftReleased() => TransitionFaceLeft();

        public override void Update(GameTime gameTime) => Avatar.Velocity = new Vector2(MathHelper.Clamp(Avatar.Velocity.X, -500, 0), Avatar.Velocity.Y);
    }
}
