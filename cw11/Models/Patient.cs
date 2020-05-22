using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
