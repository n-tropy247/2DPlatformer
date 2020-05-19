using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using UnnamedGame.Sprites;

namespace UnnamedGame.Collision
{
    public struct Collision
    {
        public readonly ISprite Sprite1;
        public readonly ISprite Sprite2;
        public readonly float TimeToCollide;
        public Vector2 Direction;
        private const double Tolerance = 0.01;

        public Collision(ISprite s1, ISprite s2, float time, Vector2 dir)
        {
            Sprite1 = s1;
            Sprite2 = s2;
            TimeToCollide = time;
            Direction = dir;
        }

        public static bool operator ==(Collision c1, Collision c2)
        {
            return (c1.Sprite1 == c2.Sprite1 && c1.Sprite2 == c2.Sprite2 && Math.Abs(c1.TimeToCollide - c2.TimeToCollide) < Tolerance &&
                    c1.Direction == c2.Direction);
        }

        public static bool operator !=(Collision c1, Collision c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            return obj != null && this == (Collision)obj;
        }

        public override int GetHashCode()
        {
            return Sprite1.GetHashCode() + Sprite2.GetHashCode() + (int)TimeToCollide;
        }
    }
    public static class CollisionDetector
    {
        public enum EntityType
        {
            Avatar,
            Default,
            Enemy,
            Tile
        }

        private const double Tolerance = 0.1;

        public static void ProcessCollisions(List<ISprite> sprites, GameTime gameTime, Game1 game)
        {
            var collisions = FindCandidates(sprites, gameTime);
            collisions.Sort((a, b) => a.TimeToCollide.CompareTo(b.TimeToCollide));

            while (collisions.Count > 0)
            {
                var currentCollision = collisions[0];
                collisions.Remove(currentCollision);
                currentCollision.Sprite1.HandleCollision(currentCollision, game);
                currentCollision.Sprite2.HandleCollision(new Collision(currentCollision.Sprite2, currentCollision.Sprite1, currentCollision.TimeToCollide, Vector2.Negate(currentCollision.Direction)), game);

                collisions = FindCandidates(sprites, gameTime);
                collisions.Sort((a, b) => a.TimeToCollide.CompareTo(b.TimeToCollide));
            }
        }

        private static Collision CheckFutureCollision(ISprite s1, ISprite s2, GameTime gameTime)
        {
            var collision = new Collision();
            var timeElapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;

            var (x, y) = new Vector2(s1.Position.X + s1.BoundBox.X, s1.Position.Y + s1.BoundBox.Y);
            var (f, f1) = new Vector2(s2.Position.X + s2.BoundBox.X, s2.Position.Y + s2.BoundBox.Y);

            var s1BoundBox = new Rectangle((int) x, (int) y, s1.BoundBox.Width, s1.BoundBox.Height);
            var s2BoundBox = new Rectangle((int) f, (int) f1, s2.BoundBox.Width, s2.BoundBox.Height);

            if (s1BoundBox.Intersects(s2BoundBox)) return new Collision(null, null, -1, Vector2.Zero); //collision already happened

            //find time for s1's left or right to collide into s2
            float leftCollideTime = -1, rightCollideTime = -1;

            //if velocities are equal, they'll never collide
            if (Math.Abs(s1.Velocity.X - s2.Velocity.X) > Tolerance)
            {
                leftCollideTime = (x - f - s2.BoundBox.Width) /
                                  (s2.Velocity.X - s1.Velocity.X);
                rightCollideTime = (f - x - s1.BoundBox.Width) /
                                   (s1.Velocity.X - s2.Velocity.X);
            }

            //find time for s1's top or bottom to collide into s2
            float topCollideTime = -1, bottomCollideTime = -1;
            if (Math.Abs(s1.Velocity.Y - s2.Velocity.Y) > Tolerance)
            {
                topCollideTime = (y - f1 - s2.BoundBox.Height) /
                                 (s2.Velocity.Y - s1.Velocity.Y);
                bottomCollideTime = (f1 - y - s1.BoundBox.Height) /
                                 (s1.Velocity.Y - s2.Velocity.Y);
            }

            //check against time elapsed to make sure collision is valid
            if (leftCollideTime >= 0 && leftCollideTime < timeElapsed)
            {
                collision = new Collision(s1, s2, leftCollideTime, new Vector2(-1, 0));
            }
            else if (rightCollideTime >= 0 && rightCollideTime < timeElapsed)
            {
                collision = new Collision(s1, s2, rightCollideTime, new Vector2(1, 0));
            }
            else if (topCollideTime >= 0 && topCollideTime < timeElapsed)
            {
                collision = new Collision(s1, s2, topCollideTime, new Vector2(0, -1));
            }
            else if (bottomCollideTime >= 0 && bottomCollideTime < timeElapsed)
            {
                collision = new Collision(s1, s2, bottomCollideTime, new Vector2(0, 1));
            }

            if (collision.Sprite1 != null && VerifyCollision(collision)) return collision;
            return new Collision();
        }

        private static bool VerifyCollision(Collision collision)
        {
            //take ABS to prevent accidental sign switch on s1's velocity
            var s1MovementDir = collision.Sprite1.Velocity *
                                new Vector2(Math.Abs(collision.Direction.X), Math.Abs(collision.Direction.Y));
            s1MovementDir.Normalize();

            var s1Distance = new Vector2(collision.Sprite1.Velocity.X * collision.TimeToCollide, collision.Sprite1.Velocity.Y * collision.TimeToCollide);
            var s2Distance = new Vector2(collision.Sprite2.Velocity.X * collision.TimeToCollide, collision.Sprite2.Velocity.Y * collision.TimeToCollide);

            var (x, y) = new Vector2(collision.Sprite1.Position.X + collision.Sprite1.BoundBox.X, collision.Sprite1.Position.Y + collision.Sprite1.BoundBox.Y) + s1Distance;
            var (f, f1) = new Vector2(collision.Sprite2.Position.X + collision.Sprite2.BoundBox.X, collision.Sprite2.Position.Y + collision.Sprite2.BoundBox.Y) + s2Distance;

            return (collision.Direction == s1MovementDir || collision.Sprite2.Velocity != Vector2.Zero)
                   && (((collision.Direction == new Vector2(-1, 0) ||
                         collision.Direction == new Vector2(1, 0)) //collision is left/right
                        && (y < f1 + collision.Sprite2.BoundBox.Height && y >= f1
                            || f1 >= y && f1 < y + collision.Sprite1.BoundBox.Height)) //and swept shapes overlap
                       || ((collision.Direction == new Vector2(0, -1) ||
                            collision.Direction == new Vector2(0, 1)) //collision is up/down
                           && x < f + collision.Sprite2.BoundBox.Width && x >= f
                           || f >= x && f < x + collision.Sprite1.BoundBox.Width)); //and swept shapes overlap

        }

        private static List<Collision> FindCandidates(List<ISprite> sprites, GameTime gameTime)
        {
            var collisions = new List<Collision>();
            sprites.Sort((s1, s2) => s1.BoundBox.X.CompareTo(s2.BoundBox.X));
            var activeList = new List<ISprite>();

            foreach (var sprite in sprites)
            {
                activeList.Add(sprite);
                foreach (var active in activeList)
                {
                    if (sprite.BoundBox.X > active.BoundBox.X + active.BoundBox.Width)
                    {
                        activeList.Remove(active);
                    }
                    else
                    {
                        var currentCollision = CheckFutureCollision(sprite, active, gameTime);
                        if (currentCollision.Sprite1 != null && currentCollision.TimeToCollide >= 0)
                        {
                            collisions.Add(currentCollision);
                        }
                    }
                }
            }

            return collisions;
        }
    }
}
