namespace EF_TPT.Domain
{
    public class CarPart : BaseEntity
    {
        public long CarId { get; set; }
        public virtual Car Car { get; set; }
        public string SerialNo { get; set; }

        public CarPart() { }

        public CarPart(string serialNumber)
        {
            this.SerialNo = serialNumber;
        }

        public override string ToString()
        {
            return string.Format("S/N: {0}", SerialNo);
        }
    }
}
