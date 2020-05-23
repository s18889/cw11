using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    //"Data Source=db-mssql;Initial Catalog=s18889;Integrated Security=True"
    public class DoctorsDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public DbSet<Medicament> Medicament { get; set; }

        public DoctorsDbContext()
        {

        }

        public DoctorsDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>((builder) =>
            {
                builder.HasKey(a => a.IdDoctor);
                //builder.Property(a => a.IdDoctor).ValueGeneratedOnAdd();
                builder.Property(a => a.FirstName).IsRequired();

                builder.HasMany(a => a.Prescriptions)
                       .WithOne(a => a.Doctor)
                       .HasForeignKey(a => a.IdDoctor)
                       .IsRequired();
            });

            modelBuilder.Entity<Medicament>((builder) =>
            {
                builder.HasKey(a => a.IdMedicament);
                builder.Property(a => a.IdMedicament).ValueGeneratedOnAdd();
                builder.Property(a => a.Name).IsRequired();

                builder.HasMany(a => a.Prescription_Medicaments)
                       .WithOne(a => a.Medicament)
                       .HasForeignKey(a => a.IdMedicament)
                       .IsRequired();
            });

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

            modelBuilder.Entity<Prescription_Medicament>((builder) =>
            {
                builder.HasKey(a => new { a.IdPrescription, a.IdMedicament });
                builder.Property(a => a.IdPrescription).IsRequired();
                builder.Property(a => a.IdMedicament).IsRequired();

            });

            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasKey(a => a.IdPrescription);
                builder.Property(a => a.IdPrescription).ValueGeneratedOnAdd();



                builder.HasMany(a => a.Prescription_Medicaments)
                       .WithOne(a => a.Prescription)
                       .HasForeignKey(a => a.IdPrescription)
                       .IsRequired();
            });

        }

    }
}
