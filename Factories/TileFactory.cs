using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Entities;
using UnnamedGame.Sprites;

namespace UnnamedGame.Factories
{
    class TileFactory : Factory<TileFactory>
    {
        private const int BlockSize = 64;
        public void LoadSheet(ContentManager mgr)
        {
            Atlas = mgr.Load<Texture2D>("tiles");
        }

        private static void BlockBoundBox(ISprite sprite)
        {
            sprite.BoundBox = new Rectangle(new Point(0, 0), new Point(BlockSize, BlockSize));
        }

        public static TileEntity CreateTile(Vector2 position)
        {
            var tile = new TileEntity(position);
            tile.Sprite = CreateGroundSprite(position);
            return tile;
        }

        public static ISprite CreateGroundSprite(Vector2 position)
        {
            ISprite sprite = new SpriteNonMovingNonAnimated(Atlas, position, 2, 1, 0);
            BlockBoundBox(sprite);
            return sprite;
        }
    }
}
