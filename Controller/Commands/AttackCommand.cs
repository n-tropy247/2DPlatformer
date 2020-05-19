namespace UnnamedGame.Controller.Commands
{
    internal class AttackCommand : BaseCommand
    {
        public AttackCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.Attack();
    }
}
