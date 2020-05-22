using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class PrescriptionDbContext : DbContext
    {
        public DbSet<Prescription> Prescriptions { get; set; }

        public PrescriptionDbContext()
        {

        }

        public PrescriptionDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasKey(a => a.IdPrescription);
                builder.Property(a => a.IdPrescription).ValueGeneratedOnAdd();
                //builder.Property(a => a.).IsRequired();
                
                
                
                builder.HasMany(a => a.Prescription_Medicaments)
                       .WithOne(a => a.Prescription)
                       .HasForeignKey(a => a.IdPrescription)
                       .IsRequired();
            });


        }

    }
}
