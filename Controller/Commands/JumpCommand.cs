namespace UnnamedGame.Controller.Commands
{
    internal class JumpCommand : BaseCommand
    {
        public JumpCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.Jump();
    }
}
