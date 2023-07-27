﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Models
{
    public class Bill
    {
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"TotalAmount: {TotalAmount}\nDueDate:{DueDate}";
        }

    }
}
