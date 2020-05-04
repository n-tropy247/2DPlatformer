using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Factories
{
    internal abstract class Factory<T> where T : Factory<T>, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new T();
                return _instance;
            }
        }

        protected Texture2D Atlas { get; set; }
    }
}
