﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Doctor
    {
        public int IdDoctor { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
