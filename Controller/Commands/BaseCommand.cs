namespace UnnamedGame.Controller.Commands
{
    internal abstract class BaseCommand : ICommand
    {
        protected Game1 Game { get; }

        protected BaseCommand(Game1 game) => Game = game;

        public abstract void Execute();
    }
}
