using Stopwatch.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfStopwatch
{
    /// <summary>
    /// Interaction logic for StopwatchControl.xaml
    /// </summary>
    public partial class StopwatchControl : UserControl
    {
        private readonly StopwatchViewModel _stopwatchViewModel = new StopwatchViewModel();
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public StopwatchControl()
        {
            InitializeComponent();
            _stopwatchViewModel = Resources["viewModel"] as StopwatchViewModel;
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs eventArgs)
            => _stopwatchViewModel.OnPropertyChanged(string.Empty);

        private void StartStopButton_Click(object sender, EventArgs eventArgs)
            => _stopwatchViewModel.StartStop();

        private void ResetButton_Click(object sender, EventArgs eventArgs)
            => _stopwatchViewModel.Reset();

        private void LapButton_Click(object sender, EventArgs eventArgs)
            => _stopwatchViewModel.LapTime();
    }
}
