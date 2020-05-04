using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using UnnamedGame.Factories;
using UnnamedGame.Sprites;

namespace UnnamedGame.World
{
    class LevelParser
    {
        private class Entities
        {
            private const string Ground = "GroundTile";
        }

        public static World Parse(Game1 game, string file)
        {
            World world;
            using (var inputReader = new StreamReader(file))
            {
                dynamic data = JsonConvert.DeserializeObject(inputReader.ReadToEnd());

                using (world = new World(game))
                {
                    foreach (var entity in data.Entities) ParseEntity(world, entity);
                }
            }

            return world;
        }

        private static void ParseEntity(World world, dynamic entity)
        {
            Vector2 start, end;
            foreach (var instance in entity.instances)
            {
                start = GetVector(instance.start);
                end = instance.end == null ? start : GetVector(instance.end);
                for (var x = (int) start.X; x <= (int) end.X; x += 64)
                for (var y = (int) start.Y; y <= (int) end.Y; y += 64)
                {
                    world.AddSprite(TileFactory.CreateTile(new Vector2(x, y)));
                }
            }
        }

        private static Vector2 GetVector(dynamic data) => new Vector2((float) data.x, (float) data.y);
    }
}
