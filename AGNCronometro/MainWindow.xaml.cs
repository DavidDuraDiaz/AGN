using AGNBack.Interfaces;
using Services;
using System;
using System.Windows;

namespace AGNCronometro
{
    public partial class MainWindow : Window
    {
        IChronometer _chronometer;

        public MainWindow()
        {
            InitializeComponent();
            _chronometer = Chronometer.Create(UpdateChronometerLabel_Event); //injeccion de dependencia sin utilizar un framework
        }

        private void UpdateChronometerLabel_Event(object sender, EventArgs e)
        {
            _chronometer.IncrementElapsedTime();
            CronometroLabel.Content = _chronometer.Value;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _chronometer.Start();
            SetIsEnabled(false, true, false);
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            _chronometer.Pause();
            SetIsEnabled(true, false, true);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _chronometer.Stop();
            SetIsEnabled(true, false, false);
        }

        private void SetIsEnabled(bool start, bool pause, bool stop)
        {
            StartButton.IsEnabled = start;
            PauseButton.IsEnabled = pause;
            StopButton.IsEnabled = stop;
        }
    }
}
