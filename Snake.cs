using System;
using System.Linq;


namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        bool Hangry;
        public Snake(Point tail, int lenght, Direction _direction):base()
        {
            direction = _direction;
            Hangry = true;
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
        internal void Move()
        {
            Point tail = pList.First();
            if (Hangry)
            {
                pList.Remove(tail);
            }
            else
            {
                Hangry = true;
            }
            Point head = GetNextPoint();

            if (!pList.Contains(head))
            {
                pList.Add(head);
                tail.Clear();
                head.Draw();
            }
            else 
                throw new TailEatException();
        }


        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.Right;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.Down;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.Up;
            }
        }

        internal bool IsHit(Walls wall)
        {
            return pList.Last().IsHit(wall);
        }

        internal bool Eat(Point food)
        {           
            if (pList.First().Equals(food))
            {
                 Hangry=false;
                 return true;
            }
            return false;
        }
    }
}
