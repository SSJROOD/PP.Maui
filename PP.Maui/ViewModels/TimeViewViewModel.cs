using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.Maui.ViewModels
{
    public class TimeViewViewModel : INotifyPropertyChanged
    {         
        public List<TimeViewModel> TimeEntries
        {
            get
            {
                return TimeServices.Current.TimeList
                    .Select(time => new TimeViewModel(time))
                    .ToList();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshTimelist()
        {
            NotifyPropertyChanged(nameof(TimeEntries));
        }
    }
}
