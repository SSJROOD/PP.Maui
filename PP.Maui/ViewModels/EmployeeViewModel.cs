using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.Maui.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public Employee EmployeeModel { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public EmployeeViewModel()
        {
            EmployeeModel = new Employee();
            setupcommands();
        }

        public string Display
        {
            get
            {
                return EmployeeModel.Display;
            }
        }


        public EmployeeViewModel(int id)
        {
            if (id == 0)
            {
                EmployeeModel = new Employee();
            }
            else
            {
                EmployeeModel = EmployeeServices.Current.Get(id);
            }
            setupcommands();
        }
        public EmployeeViewModel(Employee model)
        {
            EmployeeModel = model;
            setupcommands();
        }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }


        public void ExecuteDelete(int id)
        {
            EmployeeServices.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//Employeedetailview?empId={id}");
        }

        public void setupcommands()
        {
            DeleteCommand = new Command(e => ExecuteDelete((e as EmployeeViewModel).EmployeeModel.ID));
            EditCommand = new Command(e => ExecuteEdit((e as EmployeeViewModel).EmployeeModel.ID));
        }

        public void AddOrUpdate()
        {
            EmployeeServices.Current.AddorUpdate(EmployeeModel);
        }
    }
}
