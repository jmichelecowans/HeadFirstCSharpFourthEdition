using System;

namespace Stopwatch.View
{
    using System.Threading;
    using ViewModel;

    class StopwatchView
    {
        private StopwatchViewModel _viewModel = new StopwatchViewModel();
        private bool _quit = false;

        /// <summary>
        /// Clears the console and displays the stopwatch
        /// </summary>
        public StopwatchView()
        {
            ClearScreenAndAddHelpMessage();
            TimerCallback timerCallback = UpdateTimeCallback;
            var _timer = new Timer(timerCallback, null, 0, 10);
            while (!_quit)
                Thread.Sleep(100);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Clears the screen, adds the help message to fourth row, and makes the cursor invisible
        /// </summary>
        private static void ClearScreenAndAddHelpMessage()
        {
            Console.Clear();
            Console.CursorTop = 3; // This moves the cursor to the fourth row (rows start at 0)
            Console.WriteLine("Space to start or stop, R to reset, L for lap time, any other key to quit");
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Callback to update the time display that the time calls each time it ticks
        /// </summary>
        private void UpdateTimeCallback(object state)
        {
            WriteCurrentTime();

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).KeyChar;

                switch (key)
                {
                    case ' ':
                        _viewModel.StartStop();
                        break;
                    case 'R':
                    case 'r':
                        _viewModel.Reset();
                        break;
                    case 'L':
                    case 'l':
                        _viewModel.LapTime();
                        break;
                    default:
                        _quit = true;
                        Console.CursorVisible = true;
                        Console.CursorTop = 6;
                        Console.CursorLeft = 0;
                        break;
                }
            }
        }

        /// <summary>
        /// Writes the current time to the second row and 23rd column of the screen
        /// </summary>
        private void WriteCurrentTime()
        {
            Console.CursorTop = 1; // This moves the cursor to the second row (rows start at 0)
            Console.CursorLeft = 23; // This moves the cursor to the 23rd column (starting at 0)
            var time = $"{_viewModel.Hours}:{_viewModel.Minutes}:{_viewModel.Seconds}.{_viewModel.Tenths}";
            var lapTime = $"{_viewModel.LapHours}:{_viewModel.LapMinutes}:"
                + $"{_viewModel.LapSeconds}.{_viewModel.LapTenths}";
            Console.Write($"{time} - lap time {lapTime}");
        }
    }
}
