namespace UnnamedGame.Controller.Commands
{
    internal class DrawBoundBoxCommand : BaseCommand
    {
        public DrawBoundBoxCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => World.World.ToggleDrawBoundBox();
    }
}
