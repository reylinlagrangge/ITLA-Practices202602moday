using Microsoft.EntityFrameworkCore;
using Homework4_four_.data.entities;

namespace Homework4_four_.data
{
    public class Datacontext : DbContext
    {
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Batch> Batches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S30456N\\SQL2026;Database=projectphamacy;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laboratory>().ToTable("Laboratory");
            modelBuilder.Entity<Medication>().ToTable("Medication");
            modelBuilder.Entity<Batch>().ToTable("Batch");
        }
    }
}