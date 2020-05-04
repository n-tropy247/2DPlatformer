using Microsoft.Xna.Framework.Input;

namespace UnnamedGame.Controller
{
    internal class KeyboardController : Controller<KeyboardState, Keys>
    {
        public KeyboardController() => PrevState = Keyboard.GetState();

        protected override KeyboardState CurrentState() => Keyboard.GetState();

        protected override bool IsButtonDown(KeyboardState state, Keys button) => state.IsKeyDown(button);

        protected override bool IsButtonUp(KeyboardState state, Keys button) => state.IsKeyUp(button);
    }
}
