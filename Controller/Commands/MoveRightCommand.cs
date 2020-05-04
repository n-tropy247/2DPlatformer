namespace UnnamedGame.Controller.Commands
{
    internal class MoveRightCommand : BaseCommand
    {
        public MoveRightCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.MoveRight();
    }
}
