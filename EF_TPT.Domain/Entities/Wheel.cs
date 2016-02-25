using EF_TPT.Domain.Entities.Base;

namespace EF_TPT.Domain.Entities
{
    public class Wheel : CarPart
    {
        public enum WheelPositionEnum
        {
            ForeLeft,
            ForeRight,
            AftLeft,
            AftRight
        }

        public decimal Radius { get; set; }
        public decimal Width { get; set; }
        public string Brand { get; set; }
        public WheelPositionEnum Position { get; set; }

        public Wheel() { }
        public Wheel(string serialNumber, WheelPositionEnum position, string brand, decimal radius, decimal width) : base(serialNumber)
        {
            this.Brand = brand;
            this.Radius = radius;
            this.Width = width;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), $" - {Position} {Brand} ({Radius}\"/{Width}mm");
        }
    }
}
