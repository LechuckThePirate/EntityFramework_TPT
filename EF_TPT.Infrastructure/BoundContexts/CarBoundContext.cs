using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using EF_TPT.Domain.Entities.Base;
using EF_TPT.Infrastructure.Models.Mapping;
using System.Data.Entity;
using EF_TPT.Domain.Entities;

namespace EF_TPT.Infrastructure.BoundContexts
{
    public class CarBoundContext : DbContext
    {

        public CarBoundContext(): base("CarsDB") 
        {
            Database.SetInitializer<CarBoundContext>(null);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Wheel> Wheels { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new DoorMap());
            modelBuilder.Configurations.Add(new WheelMap());
            modelBuilder.Configurations.Add(new SeatMap());

            base.OnModelCreating(modelBuilder);
        }

        private string GetCurrentUser()
        {
            var currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
            return (currentUser != null) ? currentUser.Name : "Anonymous";
        }

        public override int SaveChanges()
        {

            ChangeTracker.Entries<BaseAuditedEntity>().ToList().ForEach(
                entry =>
                {
                    var auditedEntity = entry.Entity;
                    if (entry.State == EntityState.Added)
                    {
                        auditedEntity.Created = DateTime.Now;
                        auditedEntity.CreatedBy = GetCurrentUser();
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        auditedEntity.Updated = DateTime.Now;
                        auditedEntity.UpdatedBy = GetCurrentUser();
                    }
                });

            return base.SaveChanges();
        }
    }
}
