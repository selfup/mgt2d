using System;

namespace mono_game_template_2d
{
  public static class Program
  {
    [STAThread]
    static void GameLoop()
    {
      using (var game = new GameLoop())
        game.Run();
    }
  }
}
