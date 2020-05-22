using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public String Name { get; set; }
        public String Descryprion { get; set; }
        public String Type { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}
