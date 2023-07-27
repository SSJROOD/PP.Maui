using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
   public class BillServices
    {
       public Employee? emp { get; set; } 
        public Project? project { get; set; }
        public Bill CreateBill()
        {
            Bill mybill = new Bill();
            if(emp != null &&project !=null )
            {
                List<Time> projectTimeEntries = TimeServices.Current.TimeList
               .Where(t => t.ProjectId == project.Id && t.EmployeeId == emp.ID)
               .ToList();
                decimal totalAmount = CalculateTotalAmount(projectTimeEntries);
                mybill.TotalAmount = totalAmount;
                mybill.DueDate = DateTime.Now.AddDays(30);
                return mybill ;

            }
            return mybill;
           
        }

        private decimal CalculateTotalAmount(List<Time> timeEntries)
        {
            decimal totalAmount = 0;

            foreach (Time timeEntry in timeEntries)
            {
                Employee? employee = EmployeeServices.Current.Get(timeEntry.EmployeeId);
                if (employee != null)
                {
                    decimal rate = employee.Rate;
                    decimal amount = rate * timeEntry.Hours;
                    totalAmount += amount;
                }
            }

            return totalAmount;
        }
    }
}
