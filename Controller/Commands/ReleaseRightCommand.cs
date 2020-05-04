namespace UnnamedGame.Controller.Commands
{
    internal class ReleaseRightCommand : BaseCommand
    {
        public ReleaseRightCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.RightReleased();
    }
}
