using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mgt2d
{
  public class LoadSprites : Game
  {
    public Texture2D player;
    public LoadSprites(GraphicsDevice graphicsDevice)
    {
      string playerPath = "Content/sprites/player.png";
      using (Stream playerFile = File.OpenRead(playerPath))
        player = Texture2D.FromStream(graphicsDevice, playerFile);
    }
  }
}
