using System.ComponentModel;

namespace Stopwatch.ViewModel
{
    public class StopwatchViewModel : INotifyPropertyChanged
    {
        private readonly Model.StopwatchModel _model = new Model.StopwatchModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartStop() => _model.Running = !_model.Running;

        public void LapTime() => _model.SetLapTime();

        public void Reset() => _model.Reset();

        public string Hours => _model.Elapsed.Hours.ToString("D2");

        public string Minutes => _model.Elapsed.Minutes.ToString("D2");

        public string Seconds => _model.Elapsed.Seconds.ToString("D2");

        public string Tenths => ((int)(_model.Elapsed.Milliseconds / 100M)).ToString();

        public object LapHours => _model.LapTime.Hours.ToString("D2");

        public object LapMinutes => _model.LapTime.Minutes.ToString("D2");

        public object LapSeconds => _model.LapTime.Seconds.ToString("D2");

        public object LapTenths => ((int)(_model.LapTime.Milliseconds / 100M)).ToString();

        public void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
