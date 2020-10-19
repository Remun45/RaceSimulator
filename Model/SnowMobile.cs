using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SnowMobile : IEquipment
    {
        public int Quality { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public bool isBroken { get; set; }

        public SnowMobile(int quality, int performance, int speed, bool isBrokenlol)
        {
            Quality = quality;
            Performance = performance;
            Speed = speed;
            isBroken = isBrokenlol;
        }
    }
}
