using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UnnamedGame.Sprites
{
    class Sprite : ISprite
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }


        private const int FrameTime = 100;

        private readonly bool _animated;
        private readonly int _cols, _width, _height;
        private readonly int _startIndx, _endIndx;
        private readonly Texture2D _texture;

        private int _curFrame;
        private int _timePassed;
        private Rectangle _srcRectangle, _destRectangle;

        public Sprite(Texture2D sheet, Vector2 position, Vector2 velocity, Vector2 acceleration, int atlasRows, int atlasColumns, int start, int end, bool anim)
        {
            _texture = sheet;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
            _cols = atlasColumns;
            _startIndx = start;
            _endIndx = end;
            _curFrame = start;
            _width = _texture.Width / _cols;
            _height = _texture.Height / atlasRows;
            _animated = anim;

            _srcRectangle.Width = _width;
            _srcRectangle.Height = _height;
            _destRectangle.Width = _width;
            _destRectangle.Height = _height;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            var row = (int) (_curFrame / (float) _cols);
            var col = _curFrame % _cols;
            _srcRectangle.X = _width * col;
            _srcRectangle.Y = _height * row;
            _destRectangle.X = (int) Position.X;
            _destRectangle.Y = (int)Position.Y;

            spriteBatch.Draw(_texture, _destRectangle, _srcRectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
            Velocity += Acceleration * (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (_animated)
            {
                _timePassed += gameTime.ElapsedGameTime.Milliseconds;
                if (_timePassed > FrameTime)
                {
                    _curFrame++;
                    if (_curFrame > _endIndx)
                    {
                        _curFrame = _startIndx;
                    }

                    _timePassed -= FrameTime;
                }
            }
        }
    }
}
