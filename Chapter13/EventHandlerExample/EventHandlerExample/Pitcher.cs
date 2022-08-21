using System;

namespace EventHandlerExample
{
    class Pitcher
    {
        private int _pitchNumber = 0;

        public Pitcher(Ball ball) => ball.BallInPlay += BallInPlayEventHandler;

        private void BallInPlayEventHandler(object sender, BallEventArgs e)
        {
            _pitchNumber++;

            if (e.Distance < 98 && e.Angle < 60)
            {
                Console.WriteLine($"Pitch #{_pitchNumber}: I caught the ball");
            }
            else
            {
                Console.WriteLine($"Pitch #{_pitchNumber}: I covered first base");
            }
        }
    }
}
