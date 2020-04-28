using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mgt2d
{
  public class GameLoop : Game
  {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _player;
    private Rectangle character;

    public GameLoop()
    {
      _graphics = new GraphicsDeviceManager(this);

      Content.RootDirectory = "Content";
      IsMouseVisible = true;
    }

    protected override void Initialize()
    {
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

      int spriteSize;

      if (deviceWidth > 1919)
      {
        spriteSize = 64;
      }
      else if (deviceWidth > 1279)
      {
        spriteSize = 32;
      }
      else
      {
        spriteSize = 16;
      }

      character = new Rectangle(centerX, centerY, spriteSize, spriteSize);

      base.Initialize();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      LoadSprites sprites = new LoadSprites(GraphicsDevice);

      _player = sprites.player;
    }

    protected override void Update(GameTime gameTime)
    {
      // only support gamepads
      var gamePadState = GamePad.GetState(PlayerIndex.One);
      var gamePadButtons = gamePadState.Buttons;
      var gamePadSticks = gamePadState.ThumbSticks;

      // "-" button on switch
      var back = gamePadButtons.Back;

      // switch specific
      var sA = gamePadButtons.B;
      var sB = gamePadButtons.A;
      var sX = gamePadButtons.Y;
      var sY = gamePadButtons.X;

      if (back == ButtonState.Pressed)
      {
        Console.WriteLine("Back pressed. Exiting..");
        Exit();
      }

      if (sA == ButtonState.Pressed)
      {
        Console.WriteLine("A pressed");
      }

      if (sB == ButtonState.Pressed)
      {
        Console.WriteLine("B pressed");
      }

      if (sX == ButtonState.Pressed)
      {
        Console.WriteLine("X pressed");
      }

      if (sY == ButtonState.Pressed)
      {
        Console.WriteLine("Y pressed");
      }

      character.X = character.X + (int)(gamePadSticks.Left.X * 10.0);
      character.Y = character.Y - (int)(gamePadSticks.Left.Y * 10.0);

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Transparent);

      GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

      _spriteBatch.Begin();
      _spriteBatch.Draw(_player, character, Color.White);
      _spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
