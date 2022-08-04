using PacMan.Base;
using PacMan.Jogo;
using System;
using System.Collections.Generic;

namespace PacMan.Entidade
{
    public class Ghost : EntityBase
    {
        public override string name { get; set; } = "Ghost";
        public override char character { get; set; } = Constant.GhostChar;
        private Direction previousPosition = Direction.None;
        private int viewDistance = 5;

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.Magenta;
        }

        public override void Update()
        {
            var nextDirection = GetNextDirection();

            switch (nextDirection)
            {
                case Direction.Up:
                    previousPosition = Direction.Down;
                    break;
                case Direction.Down:
                    previousPosition = Direction.Up;
                    break;
                case Direction.Left:
                    previousPosition = Direction.Right;
                    break;
                case Direction.Right:
                    previousPosition = Direction.Left;
                    break;
                default:
                    previousPosition = Direction.None;
                    break;
            }

            var destX = x;
            var destY = y;
            if (nextDirection == Direction.Up)
                destY--;
            else if(nextDirection == Direction.Down)
                destY++;
            else if(nextDirection == Direction.Left)
                destX--;
            else if(nextDirection == Direction.Right)
                destX++;

            var destEntity = GetEntityInDirection(nextDirection, 1);
            if (destEntity.entityType == EntityType.Player)
                StartTransition(TransitionType.Dead);

            if (destX != x || destY != y)
                Move(destX, destY);
        }

        private Direction GetNextDirection()
        {
            var directions = new List<DirectionInfo>()
            {
                GetDirectionInfo(Direction.Up),
                GetDirectionInfo(Direction.Down),
                GetDirectionInfo(Direction.Left),
                GetDirectionInfo(Direction.Right)
            };
            directions.RemoveAll(d => !d.IsAvailable);

            var playerDirection = directions.Find(d => d.IsPlayerVisible);
            if (playerDirection != null)
                return playerDirection.Direction;

            if(directions.Count > 1)
                directions.RemoveAll(d => d.Direction == previousPosition);

            if (directions.Count == 0)
                return Direction.None;

            return directions[random.Next(0, directions.Count)].Direction;
        }

        private DirectionInfo GetDirectionInfo(Direction direction)
        {
            var info = new DirectionInfo()
            {
                Direction = direction,
                IsAvailable = false,
                IsPlayerVisible = false
            };

            for(int i = 1; i <= viewDistance; i++)
            {
                var entity = GetEntityInDirection(direction, i);
                if (entity == null)
                    break;

                if (entity.entityType == EntityType.Wall || entity.entityType == EntityType.Ghost)
                    break;

                if(entity.entityType == EntityType.Player)
                    info.IsPlayerVisible = true; 

                info.IsAvailable = true;
            }
            return info;
        }

        private class DirectionInfo
        {
            public Direction Direction { get; set; }
            public bool IsPlayerVisible { get; set; }
            public bool IsAvailable { get; set; }

        }
    }
}
