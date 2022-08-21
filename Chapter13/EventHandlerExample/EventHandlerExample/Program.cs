using System;

namespace EventHandlerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ball = new Ball();
            _ = new Pitcher(ball);
            _ = new Fan(ball);

            while (true)
            {
                Console.Write("Enter a number for the angle (or anything else to quit): ");
                if (!int.TryParse(Console.ReadLine(), out int angle)) break;
                Console.Write("Enter a number for the distance (or anything else to quit): ");
                if (!int.TryParse(Console.ReadLine(), out int distance)) break;

                var bat = ball.GetNewBat();
                bat.HitTheBall(new BallEventArgs(angle, distance));
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
