using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurgiNeer.Models
{
    public class Apply
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string PhoneNumber { get; set; }
        public DateTime StartDate { get; set;  }
        public string Details { get; set;  }
    }
}
