using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class MedicamentDbContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }

        public MedicamentDbContext()
        {

        }

        public MedicamentDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        }

    }
}
