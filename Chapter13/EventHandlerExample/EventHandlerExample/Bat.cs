namespace EventHandlerExample
{
    delegate void BatCallback(BallEventArgs e);

    class Bat
    {
        private readonly BatCallback _hitBallCallback;

        public Bat(BatCallback callbackDelegate) => _hitBallCallback = callbackDelegate;

        public void HitTheBall(BallEventArgs e) => _hitBallCallback?.Invoke(e);
    }
}
