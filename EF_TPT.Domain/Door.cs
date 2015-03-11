using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT.Domain
{
    public class Door : CarPart
    {
        public enum DoorPositionEnum
        {
            FrontLeft = 0,
            FrontRight = 1,
            RearLeft = 2,
            RearRight = 3
        }

        public DoorPositionEnum Position { get; set; }

        public Door() { }
        public Door(string serialNumber, DoorPositionEnum position) : base(serialNumber)
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" - Posición: {0}", Position);
        }
    }
}
