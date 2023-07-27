using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Project
    {
        public int Id
        {
            get; set;
        }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        private bool isactive;
        public bool IsActive { get { return isactive; } set { isactive = true; isactive = value; } }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; }
        public List<Client>? myClient { get; set; }
        public List<Bill>? bills { get; set; }
        public string Display
        {
            get
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            return "project ID:" + Id + "\n" + "Shortname: " + ShortName + "\n" + "Client ID: " + ClientId + "\n";
        }
    }
}
