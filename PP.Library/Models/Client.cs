using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        private bool isactive;
        public bool IsActive { get { return isactive; } set { isactive = true; isactive = value; } }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public List<Project>? Projects { get; set; }




        public string Display
        {
            get
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            return $"Name: {Name}\nID: {Id}";
        }

    }
}
