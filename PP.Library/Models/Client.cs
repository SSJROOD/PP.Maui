using PP.Library.DTO;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Client
    {
        public Client()
        {
            Name = string.Empty;
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        private bool isactive;
        public bool IsActive { get { return isactive; } set { isactive = true; isactive = value; } }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public List<Project>? Projects { get; set; }

        public Client(ClientDTO d)
        {
            this.Id = d.Id;
            this.Name = d.Name;
            this.Projects = d.Projects;
        }




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
