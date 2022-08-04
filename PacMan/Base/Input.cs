using System.Windows.Input;

namespace PacMan.Base
{
    public class Input
    {
        public InputStatus GetInput()
        {
            var status = new InputStatus();
            if (Keyboard.IsKeyDown(Key.Up))
                status.Direction = Direction.Up;
            if (Keyboard.IsKeyDown(Key.Down))
                status.Direction = Direction.Down;
            if (Keyboard.IsKeyDown(Key.Left))
                status.Direction = Direction.Left;
            if (Keyboard.IsKeyDown(Key.Right))
                status.Direction = Direction.Right;
            return status;
        }
    }

    public class InputStatus
    {
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        None, 
        Up,
        Down,
        Left,
        Right
    }
}
