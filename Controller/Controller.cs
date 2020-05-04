using System.Collections.Generic;
using System.Linq;
using UnnamedGame.Controller.Commands;

namespace UnnamedGame.Controller
{
    abstract class Controller<T, TS>
    {
        public T PrevState { get; set; }
        private Dictionary<TS, ICommand> Bindings { get; }
        private Dictionary<TS, ICommand> ReleaseBindings { get; }

        public Controller()
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

        public abstract T CurrentState();
        public abstract bool IsButtonDown(T state, TS button);
        public abstract bool IsButtonUp(T state, TS button);
    }
}
