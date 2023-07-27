using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.Maui.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time selectedTime { get; set; }
        public List<Bill> bill { get; set; }
        public string Display
        {
            get
            {
                return selectedTime.ToString();
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand CreateBillCommand { get; private set; }

        public void ExecuteDelete(Time time)
        {
            TimeServices.Current.Delete(time);
        }

        public void ExecuteCreateBill(int pid,int eid)
        {
            pid = selectedTime.ProjectId;
            eid = selectedTime.EmployeeId;
            Shell.Current.GoToAsync($"//billdetail?pid={pid}&eid={eid}");
        }
        public void ExecuteEdit(int pid, int eid)
        {
            Shell.Current.GoToAsync($"//updatetime?pID={pid}&eID={eid}");
        }

        public TimeViewModel(Time time)
        {
            selectedTime = time;
            SetupCommands();
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(c => ExecuteDelete(selectedTime));
            EditCommand = new Command(() => ExecuteEdit(selectedTime.ProjectId, selectedTime.EmployeeId));
            CreateBillCommand = new Command(() => ExecuteCreateBill(selectedTime.ProjectId, selectedTime.EmployeeId));
        }

        public TimeViewModel()
        {
            selectedTime = new Time();
            SetupCommands();
        }

        public TimeViewModel(int pId, int emId)
        {
            if (pId == 0 && emId == 0)
            {
                selectedTime = new Time();
            }
            else
            {
                selectedTime = TimeServices.Current.Get(pId, emId);
            }
            SetupCommands();
        }

        public void AddTime()
        {
            TimeServices.Current.addTime(selectedTime);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
