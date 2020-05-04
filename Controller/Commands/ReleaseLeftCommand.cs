using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UnnamedGame.Controller.Commands
{
    class ReleaseLeftCommand : BaseCommand
    {
        public ReleaseLeftCommand(Game1 game) : base(game)
        {
        }

        public override void Execute() => Game.World.LeftReleased();
    }
}
