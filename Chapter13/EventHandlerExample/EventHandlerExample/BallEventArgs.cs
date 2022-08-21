using System;

namespace EventHandlerExample
{
    class BallEventArgs : EventArgs
    {
        public int Angle { get; private set; }

        public int Distance { get; private set; }

        public BallEventArgs(int angle, int distance)
        {
            Angle = angle;
            Distance = distance;
        }
    }
}
