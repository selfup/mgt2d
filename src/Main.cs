﻿using System;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mg.Temp {
    public class GameLoop : Game {
        const string PLAYER_CONFIG = "Content/config.json";
        private ConfigModel config;
        private bool devMode;
        private int currentTimeStamp;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _player;
        private Rectangle playerRec;
        private PlayerControls playerControls;
        private int spriteSize;

        private RenderTarget2D renderTarget;

        public GameLoop() {
            _graphics = new GraphicsDeviceManager(this);

            playerControls = new PlayerControls(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            config = LoadConfig();

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

            renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, 512, 288);

            _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Viewport.Bounds.Width;
            _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.Viewport.Bounds.Height;
            _graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            Window.AllowUserResizing = true;
            Window.IsBorderless = true;

            var centerX = 0;
            var centerY = 0;

            spriteSize = 16;

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
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            _graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            _spriteBatch.Begin();
            spriteBatchDraw(gameTime);
            _spriteBatch.End();

            _graphics.GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin();
            _spriteBatch.Draw(renderTarget, new Rectangle(0, 0, 1080, 1920), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void spriteBatchDraw(GameTime gameTime) {
            if (devMode && gameTime.TotalGameTime.Seconds % 2 == 0) {
                DateTime dt = File.GetLastWriteTime(PLAYER_CONFIG);

                var timestamp =
                    (Int32)(dt.Subtract(DateTime.UnixEpoch)).TotalSeconds;

                if (timestamp != currentTimeStamp) {
                    config = LoadConfig();

                    currentTimeStamp = timestamp;
                }
            }

            playerRec.Height = config.Player.Height;
            playerRec.Width = config.Player.Width;

            Console.WriteLine(_graphics.GraphicsDevice.Viewport.Bounds.Width);

            for (int x = 0; x < _graphics.GraphicsDevice.Viewport.Bounds.Width; x += 16) {
                for (int y = 0; y < _graphics.GraphicsDevice.Viewport.Bounds.Height; y += 16) {
                    var gridElementRec = new Rectangle(playerRec.X + x, playerRec.Y + y, playerRec.Width, playerRec.Height);

                    _spriteBatch.Draw(_player, gridElementRec, Color.White);
                }
            }
        }

        private ConfigModel LoadConfig() {
            ConfigModel config;

            var fileContents = File.ReadAllText(PLAYER_CONFIG);
            config = JsonSerializer.Deserialize<ConfigModel>(fileContents);

            return config;
        }
    }
}
