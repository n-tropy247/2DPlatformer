using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Factories
{
    abstract class Factory<T> where T : Factory<T>, new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = new T();
                return instance;
            }
        }

        public static Texture2D Atlas { get; set; }
    }
}
