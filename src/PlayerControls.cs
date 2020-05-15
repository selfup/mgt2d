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

            var keyboardState = Keyboard.GetState();
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var gamePadButtons = gamePadState.Buttons;
            var gamePadSticks = gamePadState.ThumbSticks;

            // "-" button on switch
            var sBack = gamePadButtons.Back;

            // switch specific
            var sA = gamePadButtons.B;
            var sB = gamePadButtons.A;
            var sX = gamePadButtons.Y;
            var sY = gamePadButtons.X;

            // keyboard specific
            var kBack = Keys.Escape;
            var kW = Keys.W;
            var kS = Keys.S;
            var kD = Keys.D;
            var kA = Keys.A;

            if (keyboardState.IsKeyDown(kW)) {
                newY += 1;
            } else if (keyboardState.IsKeyDown(kS)) {
                newY -= 1;
            } else if (keyboardState.IsKeyDown(kD)) {
                newX += 1;
            } else if (keyboardState.IsKeyDown(kA)) {
                newX -= 1;
            }

            if (sBack == ButtonState.Pressed || keyboardState.IsKeyDown(kBack)) {
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

            character.X = character.X + (newX * 10);
            character.Y = character.Y - (newY * 10);
        }
    }
}
