using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace TaskEF
{
    class AppContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<TypeOfService> TypeOfServices { get; set; }
        public AppContext()
        {
           // Database.EnsureDeleted();
           // Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasOne(ow => ow.Owner)
                .WithMany(cars => cars.Cars)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Appointment>()
                .HasOne(ap => ap.Car)
                .WithMany(car => car.Appointments)
                .OnDelete(DeleteBehavior.Cascade);                   
            modelBuilder.Entity<Appointment>()
                .HasMany(types => types.TypeOfServices)
                .WithMany(ap => ap.Appointments);  
            modelBuilder.Entity<Owner>().HasMany(cars=>cars.Cars)
                .WithOne(ow=>ow.Owner)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TypeOfService>()
                .HasMany(ap=>ap.Appointments)
                .WithMany(ty=>ty.TypeOfServices);

        }     
        protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            opBuilder.UseSqlServer(@"Server=WS52;Database=TaskEF;Trusted_Connection=True");
        }
    }
}
