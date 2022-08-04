using PacMan.Base;
using PacMan.Jogo;
using System;

namespace PacMan.Entidade
{
    public class Wall : EntityBase
    {
        public override string name { get; set; } = "Wall";
        public override char character { get; set; } = Constant.WallChar;

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.DarkBlue;
            smoothRender = true;
        }

        public override void Update()
        {

        }
    }
}
