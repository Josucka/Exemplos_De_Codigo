using PacMan.Jogo;
using System;
using System.Collections.Generic;

namespace PacMan.Base
{
    public abstract class EntityBase
    {
        public int x { get; private set; }
        public int y { get; private set; }
        private GameScene scene;
        public bool smoothRender = false;
        public Pixel pixel = new Pixel()
        {
            BackgroundColor = ConsoleColor.Black,
            ForegroundColor = ConsoleColor.Gray
        };
        public bool isDestroyed { get; private set; } = false;
        public LinkedList<EntityBase>[,] gridView { get => (LinkedList<EntityBase>[,])scene.grid.Clone(); }
        public EntityType entityType { get => GetEntityByChar(character); }

        public Random random { get => Util.random; }

        public abstract string name { get; set; }
        public abstract char character { get; set; }

        public virtual void Start(GameScene scene, int x, int y)
        {
            this.scene = scene;
            this.x = x;
            this.y = y;
        }

        public abstract void Update();

        public void Move(int x, int y)
        {
            scene.grid[this.y, this.x].RemoveFirst();
            scene.grid[y, x].AddFirst(this);
            this.x = x;
            this.y = y;
        }

        public void Destroy()
        {
            isDestroyed = true;
            scene.DestroyEntity(this);
        }

        public EntityType GetEntityByChar(char c)
        {
            switch (c)
            {
                case Constant.PlayerChar:
                    return EntityType.Player;
                case Constant.GhostChar:
                    return EntityType.Ghost;
                case Constant.WallChar:
                    return EntityType.Wall;
                case Constant.ScoreChar:
                    return EntityType.Score;
                case Constant.SpaceChar:
                    return EntityType.Space;
                default:
                    return EntityType.None;
            }
        }

        public InputStatus GetInputs()
        {
            return scene.input.GetInput();
        }

        public EntityBase GetEntityInDirection(Direction direction, int distance)
        {
            var destX = x;
            var destY = y;
            switch (direction)
            {
                case Direction.Left:
                    destX -= distance;
                    break;
                case Direction.Right:
                    destX += distance;
                    break;
                case Direction.Up:
                    destY -= distance;
                    break;
                case Direction.Down:
                    destY += distance;
                    break;
            }

            //Out of range
            if(destY < 0 || destX < 0 || destY >= scene.ySize || destY >= scene.xSize)
                return null;

            return gridView[destY, destX].First.Value;
        }

        public void StartTransition(TransitionType type)
        {
            scene.StartTransition(type);
        }
    }
}