namespace UnnamedGame.Controller.Commands
{
    internal class ReleaseLeftCommand : BaseCommand
    {
        public ReleaseLeftCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.LeftReleased();
    }
}
