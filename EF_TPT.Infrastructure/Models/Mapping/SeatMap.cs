using EF_TPT.Domain.Entities;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class SeatMap : BaseEntityConfiguration<Seat>
    {
        public SeatMap()
        {
            this.ToTable("Seats");

            this.Property(t => t.Brand).IsRequired();
            this.Property(t => t.Material).IsRequired();
            this.Property(t => t.Type).IsRequired();
        }
    }
}
