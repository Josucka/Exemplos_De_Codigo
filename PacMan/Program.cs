using PacMan.Jogo;
using System;

namespace PacMan
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new GameController().Run();
        }
    }
}
