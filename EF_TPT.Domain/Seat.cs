using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT.Domain
{
    public class Seat : CarPart
    {
        public enum SeatMaterialEnum
        {
            Fabric = 0,
            Leather = 1
        }

        public enum SeatTypeEnum
        {
            Comfort = 0,
            Sportive = 1
        }

        public string Brand { get; set; }
        public SeatMaterialEnum Material { get; set; }
        public SeatTypeEnum Type { get; set; }

        public Seat() { }
        public Seat(string serialNumber, string brand, SeatMaterialEnum material, SeatTypeEnum type) : base(serialNumber)
        {
            this.Brand = brand;
            this.Material = material;
            this.Type = type;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" - {0} {1} in {2}", Brand, Type, Material);
        }
    }
}
