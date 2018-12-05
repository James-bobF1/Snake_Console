using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Press 'enter' to start the game :)");
                Console.ResetColor();
                Console.ReadLine();
                Walls wall = new Walls(80, 25, '_', '#', '@');
                wall.Draw();
                Point food = wall.CreateFood();
                food.Draw();
                Snake snake = new Snake(new Point(4, 6, '*'), 15, Direction.Right);
                snake.Draw();
                while (true)
                {
                    if (snake.IsHit(wall))
                    {
                        break;
                    }
                    if (snake.Eat(food))
                    {
                        food = wall.CreateFood();
                        food.Draw();
                    }
                    else
                    {
                        snake.Move();
                    }
                    Thread.Sleep(100);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.HandleKey(key.Key);
                    }
                }
            }
            catch (TailEatException e)
            {

                Console.SetCursorPosition(17, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(e.Message);
            }
            finally
            {
                WriteGameOver();
                Console.ReadLine();
            }
        }
        static void WriteGameOver()
        {
            Console.SetCursorPosition(17, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lose :( . Press 'enter' to quit the game.");
        }    
    }
}
