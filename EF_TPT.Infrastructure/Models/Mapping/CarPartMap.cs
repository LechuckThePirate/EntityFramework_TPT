using EF_TPT.Domain;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class CarPartMap : BaseEntityConfiguration<CarPart>
    {
        public CarPartMap() : base()
        {
            this.ToTable("Parts");

            this.Property(t => t.SerialNo)
                .IsRequired();

            // This is the "magic" of TPT ... we stablish which table will 
            // handle each class. Note that all classes must inherit from 
            // the ancestor class CarPart
            this.Map<Wheel>(t => t.ToTable("Wheels"))
                .Map<Door>(t => t.ToTable("Doors"))
                .Map<Seat>(t => t.ToTable("Seats"));

            this.HasRequired(t => t.Car)
                .WithMany(car => car.Parts)
                .HasForeignKey(t => t.CarId);

        }
    }
}
