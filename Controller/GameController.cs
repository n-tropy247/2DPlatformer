using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnamedGame.Controller.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UnnamedGame.Controller
{
    class GameController
    {
        private readonly KeyboardController keyboard;

        public GameController(Game1 game)
        {
            keyboard = new KeyboardController();

            var quit = new QuitCommand(game);
            BindCommand(quit, null, Keys.Q);

            var moveLeft = new MoveLeftCommand(game);
            var releaseLeft = new ReleaseLeftCommand(game);
            var moveRight = new MoveRightCommand(game);
            var releaseRight = new ReleaseRightCommand(game);
            var jump = new JumpCommand(game);
            var releaseJump = new ReleaseJumpCommand(game);
            BindCommand(moveLeft, releaseLeft, Keys.A);
            BindCommand(moveRight, releaseRight, Keys.D);
            BindCommand(jump, releaseJump, Keys.W);
        }

        public void Update()
        {
            keyboard.Update();
        }

        public void BindCommand(ICommand pressCommand, ICommand releaseCommand, Keys key)
        {
            keyboard.BindKey(pressCommand, releaseCommand, key);
        }
    }
}
