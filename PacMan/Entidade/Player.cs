using PacMan.Base;
using PacMan.Jogo;
using System;

namespace PacMan.Entidade
{
    public class Player : EntityBase
    {
        public override string name { get; set; } = "Player";
        public override char character { get; set; } = Constant.PlayerChar;

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.DarkYellow;
        }

        public override void Update()
        {
            var direction = GetInputs().Direction;
            var destX = x;
            var destY = y;
            if (direction == Direction.Right)
                destX++;
            else if (direction == Direction.Left)
                destX--;
            else if (direction == Direction.Up)
                destY--;
            else if(direction == Direction.Down)
                destY++;

            var destEntity = GetEntityInDirection(direction, 1);

            if (destEntity.entityType != EntityType.Score && destEntity.entityType != EntityType.Space)
                return;

            if (destEntity.entityType == EntityType.Score)
                destEntity.Destroy();

            if(destX != x || destY != y)
                Move(destX, destY);
        }
    }
}
