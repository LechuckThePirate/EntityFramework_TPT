﻿using EF_TPT.Domain.Entities.Base;

namespace EF_TPT.Domain.Entities
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
            return string.Concat(base.ToString(),$" - Position: {Position}");
        }
    }
}
