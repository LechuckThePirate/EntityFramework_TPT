using EF_TPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
