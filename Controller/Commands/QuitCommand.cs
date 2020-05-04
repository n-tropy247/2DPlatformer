namespace UnnamedGame.Controller.Commands
{
    internal class QuitCommand : BaseCommand
    {
        public QuitCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.Exit();
    }
}
