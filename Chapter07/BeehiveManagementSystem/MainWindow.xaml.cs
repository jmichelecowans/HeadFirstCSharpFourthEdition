using System;
using System.Windows;
using System.Windows.Threading;

namespace BeehiveManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Queen queen;
        private readonly DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            queen = Resources["queen"] as Queen;
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            WorkShift_Click(this, new RoutedEventArgs());
        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(jobSelector.Text))
            {
                queen.AssignBee(jobSelector.Text);
            }
        }

        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            queen.WorkNextShift();
        }
    }
}
