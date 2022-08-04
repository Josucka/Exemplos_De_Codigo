using PacMan.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PacMan.Jogo
{
    public class GameController
    {   
        private Renderer renderer = new Renderer();
        public void Run()
        {
            Console.Title = "Pacman Console";
            while (true)
            {
                Intro();
                Game(renderer);
            }
        }

        private void Game(Renderer renderer)
        {
            var s = new GameScene(Constant.WindowXSize, Constant.WindowYSize, renderer);
            s.Load("Map.txt");
            var sw = new Stopwatch();
            while(s.transition == TransitionType.None)
            {
                sw.Start();
                s.Tick();
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                sw.Restart();
                var target = (elapsed > Constant.GameLoopDelay) ? 0 : Constant.GameLoopDelay - elapsed;
                Task.Delay(TimeSpan.FromMilliseconds(target)).Wait();
            }

            if (s.transition == TransitionType.Finish)
                Finish();
            else
                Dead();
        }

        private void Dead()
        {
            new DeadScene().Run();
        }

        private void Finish()
        {
            new FinishScene().Run();
        }

        private void Intro()
        {
            new IntroScene().Run();
        }
    }
}
