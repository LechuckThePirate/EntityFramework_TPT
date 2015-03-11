using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT.Domain
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public virtual ICollection<CarPart> Parts { get; set; }
    }
}
