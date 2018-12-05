using System;

namespace Snake
{
    class Point : IEquatable<Point>
    {
        int x;
        int y;
        char symbol;

        public Point(int _x, int _y, char _symbol)
        {
            x = _x;
            y = _y;
            symbol = _symbol;
        }
        public Point(Point p) : this(p.x, p.y, p.symbol) { }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.Right)
            {
                x = x + offset;
            }
            else if (direction == Direction.Left)
            {
                x = x - offset;
            }
            else if (direction == Direction.Up)
            {
                y = y - offset;
            }
            else if (direction == Direction.Down)
            {
                y = y + offset;
            }
        }
        public void Clear()
        {
            symbol = ' ';
            Draw();
        }

        internal bool IsHit(Walls wall)
        {
            return x == 1 || y == 1 || x == wall.Wight-2 || y == wall.Height-2;
        }

        public  bool Equals(Point p)
        {
            return p.x == this.x && p.y==this.y;
        }
    }  
}
