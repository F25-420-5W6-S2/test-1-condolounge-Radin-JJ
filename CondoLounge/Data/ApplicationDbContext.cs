using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Condo> Condos { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Condo>()
                .HasOne(c=>c.Building)
                .WithMany(b => b.Condos)
                .HasForeignKey(b => b.BuildingId)
                .OnDelete(DeleteBehavior.NoAction);           
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u=>u.Building)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.BuildingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
