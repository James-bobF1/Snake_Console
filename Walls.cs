using System;

namespace Snake
{
    class Walls:Figure
    {
        /// <summary>
        /// Ширина
        /// </summary>
        public int Wight
        {
            get
            {
                return width;
            }

        }
        /// <summary>
        /// Высота
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }

        }
        int width,height;
        char foodSymbol;
        Random random;
        public Walls(int _width, int _height, char _symbolHorizontal,char _symbolVertical, char _foodSymbol):base()
        {
            width=_width;
            height=_height;
            foodSymbol = _foodSymbol;
            Console.SetBufferSize(width, height);
            Console.Clear();
            random = new Random();
            for (int x = 0; x < (width); x++) 
            {
                Point p = new Point(x, 1, _symbolHorizontal);
                pList.Add(p);
                p = new Point(x, height - 1, _symbolHorizontal);
                pList.Add(p);
            }
            for (int y = 1; y < (height-1) ; y++)
            {
                Point p = new Point(0, y, _symbolVertical);
                pList.Add(p);
                p = new Point(width - 1, y, _symbolVertical);
                pList.Add(p);
            }
        }
        public Point CreateFood()
        {
            int x = random.Next(2, width - 2);
            int y = random.Next(2, height - 2);
            return new Point(x, y, foodSymbol);
        }
    }
}
