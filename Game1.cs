using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UnnamedGame.Controller;
using UnnamedGame.Factories;
using UnnamedGame.World;

namespace UnnamedGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public World.World World { get; private set; }

        public static Texture2D Bound { get; private set; }

        private SpriteBatch _spriteBatch;
        private GameController _controller;

        public Game1()
        {
            using (var graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1600,
                PreferredBackBufferHeight = 896
            })
            {
                graphics.ApplyChanges();
            }
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Bound = new Texture2D(GraphicsDevice, 1, 1);
            _controller = new GameController(this);
            TileFactory.Instance.LoadSheet(Content);
            AvatarFactory.Instance.LoadSheet(Content);
            World = LevelParser.Parse(this, "./Content/level.json");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            World.Update(gameTime);
            _controller.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            World.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
