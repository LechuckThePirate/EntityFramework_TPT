using EF_TPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
