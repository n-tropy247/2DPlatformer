using System.IO;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using UnnamedGame.Factories;

namespace UnnamedGame.World
{
    internal static class LevelParser
    {
        public static World Parse(Game1 game, string file)
        {
            World world;
            using (var inputReader = new StreamReader(file))
            {
                dynamic data = JsonConvert.DeserializeObject(inputReader.ReadToEnd());

                world = new World(game);
                if (data == null) return world;
                foreach (var entity in data.Entities) ParseEntity(world, entity);
            }

            return world;
        }

        private static void ParseEntity(World world, dynamic entity)
        {
            foreach (var instance in entity.instances)
            {
                Vector2 start = GetVector(instance.start);
                Vector2 end = instance.end == null ? start : GetVector(instance.end);
                for (var x = (int) start.X; x <= (int) end.X; x += 64)
                for (var y = (int) start.Y; y <= (int) end.Y; y += 64)
                {
                    world.AddSprite(TileFactory.Instance.CreateTile(new Vector2(x, y)));
                }
            }
        }

        private static Vector2 GetVector(dynamic data) => new Vector2((float) data.x, (float) data.y);
    }
}
