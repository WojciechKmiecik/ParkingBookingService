using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ParkingBookingService.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingBookingService.Dal.Context
{
    internal class ParkingBookingContext : DbContext
    {
        private static bool created = false;
        public ParkingBookingContext()
        {
            if (!created)
            {
                Database.EnsureCreated();
            }
        }
        public ParkingBookingContext(DbContextOptions<ParkingBookingContext> options) : base(options)
        {
            // for extensibility
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<BookingEntity>().ToTable("Bookings");
            modelBuilder.Entity<GarageEntity>().ToTable("Garages");
            modelBuilder.Entity<CarEntity>().ToTable("Cars");
            //modelBuilder.Entity<BookingEntity>().HasBaseType<BaseEntity>();
            //modelBuilder.Entity<GarageEntity>().HasBaseType<BaseEntity>();
            //modelBuilder.Entity<CarEntity>().HasBaseType<BaseEntity>();

            modelBuilder.Entity<GarageEntity>().HasData(new GarageEntity() { Id = 1, Name = "Waterlooplein", Capacity = 5 });
            modelBuilder.Entity<GarageEntity>().HasData(new GarageEntity() { Id = 1, Name = "Museum", Capacity = 5 });
            modelBuilder.Entity<GarageEntity>().HasData(new GarageEntity() { Id = 1, Name = "Bijenkorf", Capacity = 5 });
        }

        public DbSet<GarageEntity> Garages { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<CarEntity> Cars { get; set; }

    }
}
