using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace mgt2d {
  class PlayerControls {
    private Game game;

    public PlayerControls(Game scopedGame) {
      game = scopedGame;
    }

    public void handleGameInput(Rectangle character) {
      var newX = (character.X * 1);
      var newY = (character.Y * 1);

      // only support gamepads
      var gamePadState = GamePad.GetState(PlayerIndex.One);
      var gamePadButtons = gamePadState.Buttons;
      var gamePadSticks = gamePadState.ThumbSticks;

      // "-" button on switch
      var sBack = gamePadButtons.Back;
      var kBack = false;

      // switch specific
      var sA = gamePadButtons.B;
      var sB = gamePadButtons.A;
      var sX = gamePadButtons.Y;
      var sY = gamePadButtons.X;

      // keyboard specific
      var kW = false;
      var kS = false;
      var kD = false;
      var kA = false;

      if (kW) { }
      if (kS) { }
      if (kD) { }
      if (kA) { }

      if (sBack == ButtonState.Pressed || kBack) {
        game.Exit();
      }

      var isController = false;

      if (sA == ButtonState.Pressed) {
        isController = true;
      }
      if (sB == ButtonState.Pressed) {
        isController = true;
      }
      if (sX == ButtonState.Pressed) {
        isController = true;
      }
      if (sY == ButtonState.Pressed) {
        isController = true;
      }

      if (isController) {
        newX = (int)gamePadSticks.Left.X;
        newY = (int)gamePadSticks.Left.Y;
      }

      character.X = newX + (newX * 10);
      character.Y = newY - (newY * 10);
    }
  }
}
