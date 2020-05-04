using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace UnnamedGame.Controller
{
    class KeyboardController : Controller<KeyboardState, Keys>
    {
        public KeyboardController() => PrevState = Keyboard.GetState();

        public override KeyboardState CurrentState() => Keyboard.GetState();

        public override bool IsButtonDown(KeyboardState state, Keys button) => state.IsKeyDown(button);

        public override bool IsButtonUp(KeyboardState state, Keys button) => state.IsKeyUp(button);
    }
}
