using Microsoft.Xna.Framework;

namespace UnnamedGame.Entities
{
    internal class TileEntity : BaseEntity
    {
        protected TileEntity(Vector2 position) : base(position)
        {
        }

        public override void HandleCollision(Collision.Collision collision, Game1 game)
        {
            Sprite?.HandleCollision(collision, game);
        }
    }
}
