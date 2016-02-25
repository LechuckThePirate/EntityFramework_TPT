using EF_TPT.Domain.Entities.Base;

namespace EF_TPT.Domain.Entities
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

        public enum SeatPositionEnum
        {
            FrontLeft,
            FrontRight
        }

        public string Brand { get; set; }
        public SeatMaterialEnum Material { get; set; }
        public SeatTypeEnum Type { get; set; }
        public SeatPositionEnum Position { get; set; }

        public Seat() { }
        public Seat(string serialNumber, SeatPositionEnum position, string brand, SeatMaterialEnum material, SeatTypeEnum type) : base(serialNumber)
        {
            this.Brand = brand;
            this.Material = material;
            this.Type = type;
            this.Position = position;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString() ,$" - Position: {Position}, {Brand} {Type} in {Material}");
        }
    }
}
