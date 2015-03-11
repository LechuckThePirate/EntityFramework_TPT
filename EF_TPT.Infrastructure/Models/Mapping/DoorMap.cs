using EF_TPT.Domain;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class DoorMap : BaseEntityConfiguration<Door>
    {
        public DoorMap()
        {
            this.ToTable("Doors");

            this.Property(t => t.Position)
                .IsRequired();
        }
    }
}
