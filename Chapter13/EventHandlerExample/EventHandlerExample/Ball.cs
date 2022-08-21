using System;

namespace EventHandlerExample
{
    class Ball
    {
        public event EventHandler<BallEventArgs> BallInPlay;

        protected void OnBallInPlay(BallEventArgs e) => BallInPlay?.Invoke(this, e);

        public Bat GetNewBat() => new(new BatCallback(OnBallInPlay));
    }
}
