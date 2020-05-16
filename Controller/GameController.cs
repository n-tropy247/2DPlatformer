using UnnamedGame.Controller.Commands;
using Microsoft.Xna.Framework.Input;

namespace UnnamedGame.Controller
{
    internal class GameController
    {
        private readonly KeyboardController _keyboard;

        public GameController(Game1 game)
        {
            _keyboard = new KeyboardController();

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

            var boundbox = new DrawBoundBoxCommand(game);
            BindCommand(boundbox, null, Keys.C);

            var attack = new AttackCommand(game);
            BindCommand(attack, null, Keys.F);
        }

        public void Update()
        {
            _keyboard.Update();
        }

        private void BindCommand(ICommand pressCommand, ICommand releaseCommand, Keys key)
        {
            _keyboard.BindKey(pressCommand, releaseCommand, key);
        }
    }
}
