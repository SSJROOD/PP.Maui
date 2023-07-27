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
    public class BillingViewModel : INotifyPropertyChanged
    {
        public Time timeEntry {  get; set; }
        public Bill myBill { get; set; }    
        public BillingViewModel(int projectId, int employeeId)
        {
            timeEntry = TimeServices.Current.Get(projectId, employeeId);
            var billServices = new BillServices
            {
                emp = EmployeeServices.Current.Get(timeEntry.EmployeeId),
                project = ProjectServices.Current.Get(timeEntry.ProjectId)
            };

            myBill = billServices.CreateBill();
        }

        public string display
        {
            get
            {
                return myBill.ToString() ?? string.Empty;
            }
        }


        public BillingViewModel(int projectId)
        {
            List<Time> timeEntries = TimeServices.Current.TimeList.Where(t => t.ProjectId == projectId).ToList();

            var billServices = new BillServices();
            decimal totalAmount = 0;
            HashSet<int> processedEmployeeIds = new HashSet<int>();

            foreach (var entry in timeEntries)
            {
                if (processedEmployeeIds.Contains(entry.EmployeeId))
                {
                    continue;
                }
                processedEmployeeIds.Add(entry.EmployeeId);

                billServices.emp = EmployeeServices.Current.Get(entry.EmployeeId);
                billServices.project = ProjectServices.Current.Get(entry.ProjectId);

                var bill = billServices.CreateBill();
                totalAmount += bill.TotalAmount;
            }

            myBill = new Bill
            {
                TotalAmount = totalAmount,
                DueDate = DateTime.Now.AddDays(30)
            };
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
