using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UnnamedGame.Controller.Commands
{
    abstract class BaseCommand : ICommand
    {
        protected Game1 Game { get; }

        public BaseCommand(Game1 game) => Game = game;

        public abstract void Execute();
    }
}
