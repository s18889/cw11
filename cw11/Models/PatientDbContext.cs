using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public PatientDbContext()
        {

        }

        public PatientDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>((builder) =>
            {
                builder.HasKey(a => a.IdPatient);
                builder.Property(a => a.IdPatient).ValueGeneratedOnAdd();
                builder.Property(a => a.FirstName).IsRequired();

                builder.HasMany(a => a.Prescriptions)
                       .WithOne(a => a.Patient)
                       .HasForeignKey(a => a.IdPatient)
                       .IsRequired();
            });

        }

    }
}
