using EF_TPT.Domain.Entities;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class WheelMap : BaseEntityConfiguration<Wheel>
    {
        public WheelMap()
        {
            this.ToTable("Wheels");

            this.Property(t => t.Brand)
                .IsRequired();

            this.Property(t => t.Radius)
                .IsRequired();

            this.Property(t => t.Width)
                .IsRequired();
        }
    }
}
