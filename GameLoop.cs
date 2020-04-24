using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mgt2d
{
  public class GameLoop : Game
  {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public GameLoop()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
    }

    protected override void Initialize()
    {
      // TODO: Add your initialization logic here

      base.Initialize();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // TODO: use this.Content to load your game content here
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

      // TODO: Add your update logic here

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}
