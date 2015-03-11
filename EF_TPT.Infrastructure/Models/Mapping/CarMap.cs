using EF_TPT.Domain;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class CarMap : BaseEntityConfiguration<Car>
    {
        public CarMap() : base()
        {
            this.ToTable("Cars");
            this.Property(t => t.Model)
                .IsRequired();
        }
    }
}
