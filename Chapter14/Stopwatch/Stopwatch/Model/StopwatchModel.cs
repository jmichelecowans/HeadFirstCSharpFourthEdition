﻿using System;

namespace Stopwatch.Model
{
    class StopwatchModel
    {
        private DateTime _startedTime;
        private bool _paused;
        private DateTime _pausedAt;
        private TimeSpan _totalPausedTime;

        /// <summary>
        /// The constructor resets the stopwatch
        /// </summary>
        public StopwatchModel() => Reset();

        /// <summary>
        /// Returns true if the stopwatch is running
        /// </summary>
        public bool Running
        {
            get => _startedTime != DateTime.MinValue && !_paused;
            set
            {
                if (value)
                {
                    _paused = false;

                    if (_pausedAt != DateTime.MinValue)
                    {
                        _totalPausedTime += DateTime.Now - _pausedAt;
                    }

                    if (_startedTime == DateTime.MinValue)
                    {
                        _startedTime = DateTime.Now;
                    }

                    _pausedAt = DateTime.MinValue;
                }

                if (!value && !_paused)
                {
                    _paused = true;
                    _pausedAt = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Returns the elapsed time, or zero if the stopwatch is not running
        /// </summary>
        public TimeSpan Elapsed => _paused ? _pausedAt - _startedTime - _totalPausedTime
            : _startedTime != DateTime.MinValue ? DateTime.Now - _startedTime - _totalPausedTime
            : TimeSpan.Zero;

        public TimeSpan LapTime { get; private set; }

        public void SetLapTime() => LapTime = Elapsed;

        public void Reset()
        {
            _startedTime = DateTime.MinValue;
            _pausedAt = DateTime.MinValue;
            _paused = false;
            _totalPausedTime = TimeSpan.Zero;
            LapTime = TimeSpan.Zero;
        }
    }
}
