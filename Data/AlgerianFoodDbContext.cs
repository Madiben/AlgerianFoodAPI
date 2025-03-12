using Microsoft.EntityFrameworkCore;
using AlgerianFoodAPI.Models;
using System;

namespace AlgerianFoodAPI.Data
{
    public class AlgerianFoodDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public AlgerianFoodDbContext(DbContextOptions<AlgerianFoodDbContext> options)
            : base(options) {
                ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
             }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Ingredients)
                .WithOne(i => i.Dish)
                .HasForeignKey(i => i.DishId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
