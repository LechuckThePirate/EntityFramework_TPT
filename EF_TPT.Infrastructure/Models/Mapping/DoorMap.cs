using EF_TPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
