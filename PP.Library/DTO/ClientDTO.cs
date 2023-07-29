using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Project>? Projects { get; set; }

        public ClientDTO()
        {
            Name = string.Empty;
            this.Projects = new List<Project>();

        }
        public ClientDTO(Client c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.Projects = new List<Project>();

        }
        public override string ToString()
        {
            return $"Name: {Name}\nID: {Id}";
        }



    }
}
