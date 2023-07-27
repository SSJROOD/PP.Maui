using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Services
{
    public class EmployeeServices
    {
        private static EmployeeServices? instance;
        private static object _lock = new object();

        public static EmployeeServices Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeServices();
                    }
                }
                return instance;
            }
        }

        private List<Employee> Myemployees;
        public List<Employee> Employees
        {
            get { return Myemployees; }
        }

        public int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(c => c.ID).Max() : 1;

            }
        }

        private EmployeeServices()
        {
            Myemployees = new List<Employee>
            {
                new Employee{Name = "Rood",Rate = 5,ID = 1},
                new Employee{Name = "no",Rate = 4.2m,ID = 2},
                new Employee{Name = "kml",Rate = 3.1m,ID = 3},
                new Employee{Name = "kj ",Rate = 2.2m,ID = 4}
        };
        }

        public Employee? Get(int id)
        {
            var employee = Myemployees.FirstOrDefault(x => x.ID == id);
            return employee;
        }

        public void Delete(int id)
        {
            var deleteemployee = Get(id);
            if (deleteemployee != null)
            {
                Myemployees.Remove(deleteemployee);
            }
        }

        public void AddorUpdate(Employee Model)
        {
            if (Model.ID == 0)
            {
                Model.ID = LastId + 1;
                Employees.Add(Model);
            }
        }
    }
}

