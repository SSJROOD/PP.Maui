using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class TimeServices
    {
        private static TimeServices? instance;
        private static object _lock = new object();

        public static TimeServices Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new TimeServices();
                    }
                }
                return instance;
            }
        }

        private List<Time> timeList;
        public List<Time> TimeList
        {
            get { return timeList; }
        }

        private TimeServices()
        {
            timeList = new List<Time>
            {
                new Time { Date = DateTime.Now, Narrative = "Worked on Project A", ProjectId = 1, EmployeeId = 1 ,Hours = 5},
                new Time { Date = DateTime.Now, Narrative = "Meeting with Client B", ProjectId = 2, EmployeeId = 1,Hours = 5 },
                new Time { Date = DateTime.Now, Narrative = "Research for Project C", ProjectId = 3, EmployeeId = 2,Hours = 5 }
            };


        }

        public Time? Get(int projectId, int employeeId)
        {
            return timeList.FirstOrDefault(t => t.ProjectId == projectId && t.EmployeeId == employeeId);
        }


        public void Delete(int projectId, int employeeId)
        {
            var timeToRemove = timeList.FirstOrDefault(t => t.ProjectId == projectId && t.EmployeeId == employeeId);
            if (timeToRemove != null)
            {
                timeList.Remove(timeToRemove);
            }
        }

        public void Delete(Time time)
        {
            Delete(time.ProjectId, time.EmployeeId);
        }


        public void addTime(Time selectedTime)
        {
            var emp = EmployeeServices.Current.Get(selectedTime.EmployeeId);
            var proj = ProjectServices.Current.Get(selectedTime.ProjectId);
            if(emp != null && proj != null)
            {
                TimeList.Add(selectedTime);
            }
        }
    }
}
