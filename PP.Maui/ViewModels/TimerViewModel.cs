﻿using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.Maui.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        public Project Project { get; set; }
        public string TimerDisplay
        {
            get
            {
                var time = stopwatch.Elapsed;
                var str = string.Format("{0:00}:{1:00}:{2:00}",
              time.Hours,
              time.Minutes,
              time.Seconds);
                return str;
            }
        }

        public string ProjectDisplay
        {
            get
            {
                return Project.ShortName;
            }
        }

        private IDispatcherTimer timer { get; set; }
        private Stopwatch stopwatch { get; set; }

        public ICommand StartCommand { get; private set; }
        public ICommand StopCommand { get; private set; }

        public void ExecuteStart()
        {
            stopwatch.Start();
            timer.Start();
        }

        public void ExecuteStop()
        {
            stopwatch.Stop();
        }

        private void SetupCommands()
        {
            StartCommand = new Command(ExecuteStart);
            StopCommand = new Command(ExecuteStop);
        }
        public TimerViewModel(int projectId)
        {
            Project = ProjectServices.Current.Get(projectId) ?? new Project();
            stopwatch = new Stopwatch();
            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsRepeating = true;

            timer.Tick += Timer_Tick;
            SetupCommands();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timer.IsRunning)
            {
                NotifyPropertyChanged(nameof(TimerDisplay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
