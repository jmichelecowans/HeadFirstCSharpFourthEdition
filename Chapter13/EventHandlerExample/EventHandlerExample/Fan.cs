using System;

namespace EventHandlerExample
{
    class Fan
    {
        private int _pitchNumber = 0;

        public Fan(Ball ball) => ball.BallInPlay += BallInPlayEventHandler;

        private void BallInPlayEventHandler(object sender, BallEventArgs e)
        {
            _pitchNumber++;

            if (e.Distance > 400 && e.Angle > 30)
            {
                Console.WriteLine($"Pitch #{_pitchNumber}: Home run! I’m going for the ball!");
            }
            else
            {
                Console.WriteLine($"Pitch #{_pitchNumber}: Woo-hoo! Yeah!");
            }
        }
    }
}
