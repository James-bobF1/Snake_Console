
namespace Snake
{
    class Line : Figure
    {
        public Line(Point start, Direction direction, int offset):base()
        {
            for (int i = 0; i <= offset; i++)
            {
                Point p = new Point(start);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
    }
}
