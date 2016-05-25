using System.Collections.Generic;
using EF_TPT.Domain.Entities.Base;

namespace EF_TPT.Domain.Entities
{
    public class Car : BaseAuditedEntity
    {
        public string Model { get; set; }
        public virtual ICollection<CarPart> Parts { get; set; }

        public virtual EntidadGemela Gemela { get; set; }
    }
}