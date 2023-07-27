using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Employee
    {
        public String? Name { get; set; }
        public decimal Rate { get; set; }
        public int ID { get; set; }

        public string Display
        {
            get
            {
                return ToString();

            }
        }
        public override string ToString()
        {
            return "ID: " + ID + "\nName: " + Name + "\nRate:" + Rate + "\n";
        }
    }
}
