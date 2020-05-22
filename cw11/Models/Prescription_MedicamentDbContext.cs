using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Prescription_MedicamentDbContext : DbContext
    {
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public Prescription_MedicamentDbContext()
        {

        }

        public Prescription_MedicamentDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription_Medicament>((builder) =>
            {
                builder.HasKey(a => new { a.IdPrescription,a.IdMedicament });
                builder.Property(a => a.IdPrescription).IsRequired();
                builder.Property(a => a.IdMedicament).IsRequired();
                //builder.Property(a => a.).IsRequired();




            });


        }

    }
}
