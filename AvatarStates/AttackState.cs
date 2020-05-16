using System;
using Microsoft.Xna.Framework;
using UnnamedGame.Entities;

namespace UnnamedGame.AvatarStates
{
    internal class AttackState : BaseState
    {
        private const int AttackTimeMillis = 1000;
        private float _time;
        protected bool MoveLeftQueued, MoveRightQueued;

        protected AttackState(AvatarEntity avatar) : base(avatar)
        {
            Avatar.Acceleration = new Vector2(0, 0);
            Avatar.Velocity = new Vector2(0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            _time += gameTime.ElapsedGameTime.Milliseconds;
            Console.WriteLine(_time);
            if (_time >= AttackTimeMillis)
            {
                TransitionNextState();
            }
            base.Update(gameTime);
        }

        public override void LeftReleased() => MoveLeftQueued = false;

        public override void MoveLeft()
        {
            if (!MoveRightQueued)
                MoveLeftQueued = true;
        }

        public override void RightReleased() => MoveRightQueued = false;

        public override void MoveRight()
        {
            if (!MoveLeftQueued)
                MoveRightQueued = true;
        }

        private void TransitionNextState()
        {
            if (!MoveLeftQueued && !MoveRightQueued)
                TransitionFaceLeft();
            else if (MoveLeftQueued)
                TransitionMoveLeft();
            else
                TransitionMoveRight();
        }
    }
}
