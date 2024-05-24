using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Numerics;
using LAbBA3.Models;
namespace LAbBA3.DB_
{
    public class DB : DbContext
    {
        public DbSet<Star> Stars { get; set; }
        public DbSet<BufferZone> Buffer { get; set; }
        public DbSet<Moon> Moons { get; set; }
        public DbSet<Planet> Planets { get; set; }

        public DB(DbContextOptions<DB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BufferZone>()
                .HasKey(bg => new { bg.PlanetId, bg.MoonId });

            modelBuilder.Entity<BufferZone>()
                .HasOne(bg => bg.Planet)
                .WithMany(b => b.Buffer)
                .HasForeignKey(bg => bg.PlanetId);

            modelBuilder.Entity<BufferZone>()
                .HasOne(bg => bg.Moon)
                .WithMany(g => g.Buffer)
                .HasForeignKey(bg => bg.MoonId);
        }
    }
}
