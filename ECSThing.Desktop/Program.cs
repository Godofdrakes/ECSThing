using System;

namespace ECSThing.Desktop
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ECSGame())
                game.Run();
        }
    }
}
