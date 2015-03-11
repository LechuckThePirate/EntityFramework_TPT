using EF_TPT.Domain;
using EF_TPT.Infrastructure.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT.Infrastructure.BoundContexts
{
    public class CarBoundContext : DbContext
    {

        public CarBoundContext(): base("CarsDB") 
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarBoundContext>());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Wheel> Wheels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new DoorMap());
            modelBuilder.Configurations.Add(new WheelMap());
            modelBuilder.Configurations.Add(new SeatMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
