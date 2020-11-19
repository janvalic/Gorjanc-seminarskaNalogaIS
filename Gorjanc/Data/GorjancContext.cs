using Gorjanc.Models;
using Microsoft.EntityFrameworkCore;

namespace Gorjanc.Data
{
    public class GorjancContext : DbContext
    {
        public GorjancContext(DbContextOptions<GorjancContext> options) : base(options)
        {
        }

        public DbSet<Oseba> Osebe { get; set; }
        public DbSet<Obisk> Obiskani { get; set; }
        public DbSet<Vrh> Vrhovi { get; set; }
        public DbSet<Slika> Slike { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oseba>().ToTable("Oseba");
            modelBuilder.Entity<Obisk>().ToTable("Obisk");
            modelBuilder.Entity<Vrh>().ToTable("Vrh");
            modelBuilder.Entity<Slika>().ToTable("Slika");
        }
    }
}