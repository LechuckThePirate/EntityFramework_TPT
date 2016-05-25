using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_TPT.Domain.Entities;

namespace EF_TPT.Infrastructure.Models.Mapping
{
    public class EntidadGemelaMap : BaseEntityConfiguration<EntidadGemela>
    {
        public EntidadGemelaMap()
        {
            this.ToTable("Gemelas");
        }

    }
}
