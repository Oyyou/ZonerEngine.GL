using System;

namespace ZonerEngine.GL
{
  public static class Program
  {
    [STAThread]
    static void Main()
    {
      using (var game = new ExampleGame())
        game.Run();
    }
  }
}
