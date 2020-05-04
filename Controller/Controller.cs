using System.Collections.Generic;
using System.Linq;
using UnnamedGame.Controller.Commands;

namespace UnnamedGame.Controller
{
    internal abstract class Controller<T, TS>
    {
        protected T PrevState { get; set; }
        private Dictionary<TS, ICommand> Bindings { get; }
        private Dictionary<TS, ICommand> ReleaseBindings { get; }

        protected Controller()
        {
            Bindings = new Dictionary<TS, ICommand>();
            ReleaseBindings = new Dictionary<TS, ICommand>();
        }

        public void Update()
        {
            var currentState = CurrentState();

            foreach (var button in Bindings.Keys.Where(button =>
                IsButtonDown(currentState, button) && IsButtonUp(PrevState, button)))
                Bindings[button].Execute();
            foreach (var button in ReleaseBindings.Keys.Where(button =>
                IsButtonUp(currentState, button) && IsButtonDown(PrevState, button)))
                ReleaseBindings[button].Execute();
            PrevState = currentState;
        }

        public void BindKey(ICommand pressCommand, ICommand releaseCommand, TS button)
        {
            Bindings.Add(button, pressCommand);
            if (releaseCommand != null)
            {
                ReleaseBindings.Add(button, releaseCommand);
            }
        }

        protected abstract T CurrentState();
        protected abstract bool IsButtonDown(T state, TS button);
        protected abstract bool IsButtonUp(T state, TS button);
    }
}
