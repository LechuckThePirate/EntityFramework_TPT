namespace EF_TPT.Domain.Entities.Base
{
    public class CarPart : BaseAuditedEntity
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
            return $"      - S/N: {SerialNo}";
        }
    }
}
