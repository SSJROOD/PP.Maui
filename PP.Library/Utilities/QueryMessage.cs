using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Utilities
{
    public class QueryMessage
    {
        private string? message;
        public string Query
        {
            get => message ?? string.Empty;
            set
            {
                message = value;
            }
        }
    }
}
