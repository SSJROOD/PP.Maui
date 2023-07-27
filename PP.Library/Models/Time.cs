using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Time
    {
        public DateTime Date { get; set; }
        public String? Narrative { get; set; }
        public int ProjectId { get; set; }
        public int Hours { get; set; }
        public List<Project>? Projects { get; set; }
        public int EmployeeId { get; set; }


        public override string ToString()
        {
            return $"Date:{Date}\nEmployee ID:{EmployeeId}\nProject ID: {ProjectId}\n";
        }
    }
}
