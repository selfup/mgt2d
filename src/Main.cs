using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mg.Temp {
    public class GameLoop : Game {
        const string PLAYER_CONFIG = "Content/config.json";
        private bool devMode;
        private int currentTimeStamp;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _player;
        private Rectangle playerRec;
        private PlayerControls playerControls;
        private int spriteSize;

        public GameLoop() {
            _graphics = new GraphicsDeviceManager(this);

            playerControls = new PlayerControls(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            if (Environment.GetEnvironmentVariable("MONOGAME_DEV") == "true") {
                devMode = true;

                Int32 unixTimestamp =
                    (Int32)(
                        DateTime
                        .UtcNow
                        .Subtract(new DateTime(1970, 1, 1))
                    ).TotalSeconds;

                currentTimeStamp = unixTimestamp;
            }

            var displayWidth = _graphics.GraphicsDevice.DisplayMode.Width;
            var displayHeight = _graphics.GraphicsDevice.DisplayMode.Height;

            _graphics.PreferredBackBufferWidth = displayWidth;
            _graphics.PreferredBackBufferHeight = displayHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            Window.AllowUserResizing = true;
            Window.IsBorderless = true;

            var deviceWidth = GraphicsDevice.Viewport.Bounds.Width;
            var deviceHeight = GraphicsDevice.Viewport.Bounds.Height;

            var centerX = deviceWidth / 2;
            var centerY = deviceHeight / 2;

            if (deviceWidth > 1919) {
                spriteSize = 64;
            } else if (deviceWidth > 1279) {
                spriteSize = 32;
            } else {
                spriteSize = 16;
            }

            playerRec = new Rectangle(centerX, centerY, spriteSize, spriteSize);

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadSprites _sprites = new LoadSprites(GraphicsDevice);
            _player = _sprites.sprites["player"];
        }

        protected override void Update(GameTime gameTime) {
            playerControls.handleGameInput(playerRec);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Transparent);
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            if (devMode) {
                DateTime dt = File.GetLastWriteTime(PLAYER_CONFIG);

                var timestamp =
                    (Int32)(dt.Subtract(DateTime.UnixEpoch)).TotalSeconds;

                if (timestamp != currentTimeStamp) {
                    ConfigModel config;
                    var fileContents = File.ReadAllText(PLAYER_CONFIG);
                    config = JsonSerializer.Deserialize<ConfigModel>(fileContents);

                    currentTimeStamp = timestamp;

                    playerRec.Height = config.Player.Height;
                    playerRec.Width = config.Player.Width;
                }
            }

            _spriteBatch.Begin();
            _spriteBatch.Draw(_player, playerRec, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
