using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.Maui.ViewModels
{
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EmployeeViewModel> YourEmployees
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<EmployeeViewModel>
                   (
                   EmployeeServices
                   .Current
                   .Employees
                   .Select(e => new EmployeeViewModel(e)).ToList()
                   );
                }
                return new ObservableCollection<EmployeeViewModel>
                   (
                   EmployeeServices
                   .Current
                   .Employees
                   .Where(e => e.Name.ToUpper().Contains(Query.ToUpper()))
                   .Select(e => new EmployeeViewModel(e)).ToList()
                   );


            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshEmployee()
        {
            NotifyPropertyChanged(nameof(YourEmployees));
        }

        public string Query { get; set; }

        public void ExecuteSearch()
        {
            RefreshEmployee();
        }
    }
}
