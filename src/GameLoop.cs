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

    public GameLoop()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
    }

    protected override void Initialize()
    {
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
      var backButtonState = GamePad.GetState(PlayerIndex.One).Buttons.Back;
      var backButtonPressed = backButtonState == ButtonState.Pressed;
      var isEscapePressed = Keyboard.GetState().IsKeyDown(Keys.Escape);

      if (backButtonPressed || isEscapePressed)
      {
        Exit();
      }

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Transparent);

      _spriteBatch.Begin();

      for (int i = 0; i < 300; i++)
      {
        _spriteBatch.Draw(_player, new Rectangle(i, i, i, i), Color.White);
      }

      _spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
