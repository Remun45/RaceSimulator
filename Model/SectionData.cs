using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SectionData
    {
        public IParticipant Left { get; set; }
        public int DistanceLeft { get; set; }
        public IParticipant Right { get; set; }
        public int DistanceRight { get; set; }
        public SectionData(IParticipant participantLeft, int left, IParticipant participantRight, int right)
        {
            this.Left = participantLeft;
            this.DistanceLeft = left;
            this.Right = participantRight;
            this.DistanceRight = right;
        }
        public SectionData()
        {

        }
    }
}
