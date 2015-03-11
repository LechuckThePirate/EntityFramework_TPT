namespace EF_TPT.Domain
{
    public class Wheel : CarPart
    {
        public double Radius { get; set; }
        public double Width { get; set; }
        public string Brand { get; set; }

        public Wheel() { }
        public Wheel(string serialNumber, string brand, double radius, double width) : base(serialNumber)
        {
            this.Brand = brand;
            this.Radius = radius;
            this.Width = width;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" - {0} {1}\"/{2}mm", Brand, Radius, Width);
        }
    }
}
