namespace UnnamedGame.Controller.Commands
{
    internal class MoveLeftCommand : BaseCommand
    {
        public MoveLeftCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.MoveLeft();
    }
}
