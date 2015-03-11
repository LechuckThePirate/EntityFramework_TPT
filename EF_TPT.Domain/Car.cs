using System.Collections.Generic;

namespace EF_TPT.Domain
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public virtual ICollection<CarPart> Parts { get; set; }
    }
}
