using EF_TPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class CarPartMap : BaseEntityConfiguration<CarPart>
    {
        public CarPartMap() : base()
        {
            this.ToTable("Parts");

            this.Map<Wheel>(t => t.ToTable("Wheels"))
                .Map<Door>(t => t.ToTable("Doors"))
                .Map<Seat>(t => t.ToTable("Seats"));

            this.HasRequired(t => t.Car)
                .WithMany(car => car.Parts)
                .HasForeignKey(t => t.CarId);

        }
    }
}
