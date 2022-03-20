namespace Paintball
{
    class PaintballGun
    {
        public int MagazineSize { get; private set; }

        public int BallsLoaded { get; private set; }

        public bool IsEmpty => BallsLoaded == 0;

        private int _balls = 0;
        public int Balls
        {
            get { return _balls; }
            set
            {
                if (value > 0)
                    _balls = value;
                Reload();
            }
        }

        public PaintballGun(int balls, int magazineSize, bool loaded)
        {
            _balls = balls;
            MagazineSize = magazineSize;
            if (!loaded) Reload();
        }

        public void Reload()
        {
            if (_balls > MagazineSize)
            {
                BallsLoaded = MagazineSize;
            }
            else
            {
                BallsLoaded = _balls;
            }
        }

        public bool Shoot()
        {
            if (IsEmpty) return false;
            BallsLoaded--;
            _balls--;
            return true;
        }
    }
}
