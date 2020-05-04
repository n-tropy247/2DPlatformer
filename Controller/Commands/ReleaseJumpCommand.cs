namespace UnnamedGame.Controller.Commands
{
    internal class ReleaseJumpCommand : BaseCommand
    {
        public ReleaseJumpCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.JumpReleased();
    }
}
